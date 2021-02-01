using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManagementForMultiTasking
{
    public static class AppiumOpt
    {
        //获取一个可用的端口
        public static int getAvailablePort(int minPort,int maxPort)
        {
            //自动提取代码
            Random rd = new Random();
            int availablePort = rd.Next(minPort, maxPort);
            int num = 0;
            while (PortInUse(availablePort))
            {
                if (num == 50)
                {
                    break;
                }
                availablePort = rd.Next(minPort, maxPort);
                num++;
            }
            //说明随机50次仍未找到可用端口，端口已被占满
            if (num == 50)
            {
                return 0;
            }

            return availablePort;
        }

        //查看端口是否已被占用
        public static bool PortInUse(int port)
        {
            bool inUse = false;

            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
            //获取所有的TCP端口
            IPEndPoint[] iPEndPoints = ipProperties.GetActiveTcpListeners();

            foreach (IPEndPoint endPoint in iPEndPoints)
            {
                if (endPoint.Port == port)
                {
                    inUse = true;
                    return inUse;
                }
            }

            iPEndPoints = ipProperties.GetActiveUdpListeners();

            foreach (IPEndPoint endPoint in iPEndPoints)
            {
                if (endPoint.Port == port)
                {
                    inUse = true;
                    return inUse;
                }
            }

            return inUse;
        }

        //调用命令行执行任务
        public static void callCmd(Object order)
        {
            string cmdOrder = (string)order;
            Process cmdProcess = new Process();
            cmdProcess.StartInfo.FileName = "cmd.exe";
            cmdProcess.StartInfo.RedirectStandardInput = true;
            cmdProcess.StartInfo.UseShellExecute = false;
            cmdProcess.StartInfo.CreateNoWindow = true;
            cmdProcess.Start();
            cmdProcess.StandardInput.WriteLine(cmdOrder);
            cmdProcess.StandardInput.WriteLine("exit");
            cmdProcess.StandardInput.Flush();
        }

        public static void communicate(int socketPort,MySqlConnection conn, string taskId, DataGridView taskInfoDataGridView)
        {
            Socket serverSocket = null;
            Socket socket = null;

            try
            {
                //初始化socket
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ip = IPAddress.Parse("127.0.0.1");//本机IP
                IPEndPoint ipend = new IPEndPoint(ip, socketPort);//网络终结点表示为IP地址和端口号
                serverSocket.Bind(ipend);
                serverSocket.Listen(10);

                //等待用户连接
                socket = serverSocket.Accept();

                //记录本次启动任务使用的socket端口号
                DatabaseOpt.updateOne(conn, taskId, "socketPort", socketPort.ToString());

                //附件名列表（未来将取证部分引入时会用到）
                List<String> attachmentsList = new List<string>();

                //通知客户端服务端已准备好
                byte[] frameHeader = new byte[] { (byte)0x00 };
                byte[] frameLength = intToBytes(4);
                byte[] frameCmd = new byte[] { (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x00 };
                byte[] frameEnd = new byte[] { (byte)0xff };

                byte[] frame1 = arrayJoin(frameHeader, frameLength);
                byte[] frame2 = arrayJoin(frame1, frameCmd);
                byte[] frame = arrayJoin(frame2, frameEnd);
                socket.Send(frame);

                //接收并解析客户端回传的进度信息
                while (true)
                {
                    byte[] receiveFrameHeader = new byte[1];
                    socket.Receive(receiveFrameHeader);
                    byte[] receiveFrameLength = new byte[4];
                    socket.Receive(receiveFrameLength);
                    int length = byteToInt(receiveFrameLength);//命令+内容长度
                    length -= 4;//内容长度
                    byte[] receiveCommand = new byte[4];
                    socket.Receive(receiveCommand);
                    byte[] attachmentCommand = new byte[] { 0x00, 0x00, 0x00, 0x02 };//附件名报文命令
                    byte[] progressCommand = new byte[] { 0x00, 0x00, 0x00, 0x01 };//进度报文命令
                    byte[] attachmentEndCommand = new byte[] { 0x00, 0x00, 0x00, 0x03 };//附件名传送结束命令
                    if (byteArrayEquals(receiveCommand, attachmentCommand))
                    {
                        if (length > 0)//有附件内容
                        {
                            byte[] attachmentContent = new byte[length];
                            socket.Receive(attachmentContent);
                            string content = Encoding.UTF8.GetString(attachmentContent, 0, length);
                            attachmentsList.Add(content);
                        }
                    }
                    if (byteArrayEquals(receiveCommand, progressCommand))
                    {
                        if (length > 0)//有内容
                        {
                            byte[] receiveContent = new byte[length];
                            socket.Receive(receiveContent);
                            //string content = receiveContent.ToString();
                            string content = Encoding.UTF8.GetString(receiveContent, 0, length);
                            TaskProgress taskProgress = new TaskProgress();
                            JObject contentJObject = JObject.Parse(content);
                            taskProgress.TASK_ID = (string)contentJObject["TASK_ID"];
                            taskProgress.SUB_TASK_ID = (string)contentJObject["SUB_TASK_ID"];
                            taskProgress.PROGRESS_CUR = (int)contentJObject["PROGRESS_CUR"];
                            taskProgress.PROGRESS_TOTAL = (int)contentJObject["PROGRESS_TOTAL"];
                            taskProgress.STATUS_CODE = (string)contentJObject["STATUS_CODE"];
                            taskProgress.STATUS_TEXT = (string)contentJObject["STATUS_TEXT"];

                            //更新任务进度
                            DatabaseOpt.updateOne(conn, taskId, "taskProgress", taskProgress.STATUS_TEXT);
                            TaskInfoDataGridViewOpt.updateTaskInfoDataGridView(taskInfoDataGridView);
                        
                        }
                    }
                    byte[] receiveFrameEnd = new byte[1];
                    socket.Receive(receiveFrameEnd);
                    byte[] endCommand = new byte[] { 0x00, 0x00, 0xff, 0xff };
                    if (byteArrayEquals(endCommand, receiveCommand))
                    {
                        break;
                    }
                    if (byteArrayEquals(attachmentEndCommand, receiveCommand))
                    {
                        break;
                    }
                }

            }
            catch (Exception)
            {
                //更新出错时的任务进度
                DatabaseOpt.updateOne(conn, taskId, "taskStatus", "登录任务执行出错");
                TaskInfoDataGridViewOpt.updateTaskInfoDataGridView(taskInfoDataGridView);
            }
            finally
            {
                closeSocket(serverSocket, socket);
            }


        }

        //int类型转为byte数组
        public static byte[] intToBytes(int value)
        {
            byte[] bytes = new byte[4];
            bytes[3] = (byte)(value >> 24);
            bytes[2] = (byte)(value >> 16);
            bytes[1] = (byte)(value >> 8);
            bytes[0] = (byte)(value >> 0);
            return bytes;
        }

        //byte数组合并
        public static byte[] arrayJoin(byte[] a, byte[] b)
        {
            byte[] arr = new byte[a.Length + b.Length];
            for (int i = 0; i < a.Length; i++)
            {
                arr[i] = a[i];
            }
            for (int j = 0; j < b.Length; j++)
            {
                arr[a.Length + j] = b[j];
            }

            return arr;

        }

        //byte数组转换为int
        public static int byteToInt(byte[] bytes)
        {
            return (int)((((bytes[3] & 0xff) << 24) | ((bytes[2] & 0xff) << 16) | ((bytes[1] & 0xff << 8) | ((bytes[0] & 0xff) << 0))));
        }

        //判断两个byte数组是否相等
        public static bool byteArrayEquals(byte[] b1, byte[] b2)
        {
            if (b1 == null || b2 == null) return false;
            if (b1.Length != b2.Length) return false;
            for (int i = 0; i < b1.Length; i++)
            {
                if (b1[i] != b2[i])
                {
                    return false;
                }
            }
            return true;
        }

        //关闭socket连接
        public static void closeSocket(Socket serverSocket,Socket socket)
        {
            if (serverSocket != null)
            {
                serverSocket.Close();
            }
            if (socket != null)
            {
                socket.Close();
            }
        }

        //根据端口号关闭appium
        public static void endAppium(int port)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            List<int> list_pid = GetPidByPort(p, port);
            if (list_pid.Count == 0)
            {
                return;
            }

            PidKill(p, list_pid);

        }


        public static void PidKill(Process p, List<int> list_pid)
        {
            p.Start();
            foreach (var item in list_pid)
            {
                p.StandardInput.WriteLine("taskkill /pid " + item + " /f");
                p.StandardInput.WriteLine("exit");
            }
            p.Close();

            Thread.Sleep(1000);
        }

        public static List<int> GetPidByPort(Process p, int port)
        {
            int result;
            bool b = true;
            p.Start();
            p.StandardInput.WriteLine(string.Format("netstat -ano|findstr \"{0}\"", port));
            p.StandardInput.WriteLine("exit");
            StreamReader reader = p.StandardOutput;
            string strLine = reader.ReadLine();
            List<int> list_pid = new List<int>();
            while (!reader.EndOfStream)
            {
                strLine = strLine.Trim();
                if (strLine.Length > 0 && ((strLine.Contains("TCP") || strLine.Contains("UDP"))))
                {
                    Regex r = new Regex(@"\s+");
                    string[] strArr = r.Split(strLine);
                    if (strArr.Length >= 4)
                    {
                        b = int.TryParse(strArr[4], out result);
                        if (b && !list_pid.Contains(result))
                            list_pid.Add(result);
                    }
                }
                strLine = reader.ReadLine();
            }
            p.WaitForExit();
            reader.Close();
            p.Close();
            return list_pid;
        }

    }
}
