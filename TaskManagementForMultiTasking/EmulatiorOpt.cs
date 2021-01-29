using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementForMultiTasking
{
    public static class EmulatiorOpt
    {
        //开启某个编号模拟器
        public static bool startEmu(string index)
        {
            List<string> ans = hasReturnCmd("memuc start -i " + index);
            for (int i = 0; i < ans.Count; i++)
            {
                if (ans[i].Contains("SUCCESS"))
                {
                    return true;
                }
            }
            return false;
        }
        //关闭某个编号的模拟器
        public static void shutdownEmu(string index)
        {
            noReturnCmd("memuc stop -i " + index);
        }
        //删除某个编号的模拟器
        public static bool removeEmu(string index)
        {
            List<string> ans = hasReturnCmd("memuc remove -i " + index);
            for (int i = 0; i < ans.Count; i++)
            {
                if (ans[i].Contains("SUCCESS"))
                {
                    return true;
                }
            }
            return false;
        }
        //创建一个模拟器，并返回模拟器编号
        public static int createEmu()
        {
            List<string> EmuLists = hasReturnCmd("memuc listvms");
            int pre = -1;
            for (int i = 0; i < EmuLists.Count; i++)
            {
                if (EmuLists[i].Contains("逍遥模拟器"))
                {
                    string[] lists = EmuLists[i].Split(',');
                    int index = int.Parse(lists[0].Trim());
                    if (index - 1 != pre)
                    {
                        break;
                    }
                    else
                    {
                        pre = index;
                    }
                }

            }
            doCreateEmu();
            return pre + 1;
        }
        private static void doCreateEmu()
        {
            noReturnCmd("memuc create 71");
        }
        private static void noReturnCmd(Object order)
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
            cmdProcess.WaitForExit();

        }
        public static List<string> hasReturnCmd(string cmd)
        {
            List<string> list = new List<string>();

            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;

            p.Start();
            //p.StandardInput.WriteLine("memuc listvms");
            p.StandardInput.WriteLine(cmd);
            p.StandardInput.WriteLine("exit");
            StreamReader reader = p.StandardOutput;
            string strLine = reader.ReadLine();
            while (!reader.EndOfStream)
            {
                strLine = strLine.Trim();
                list.Add(strLine);
                strLine = reader.ReadLine();
            }
            return list;
        }
    }
}
