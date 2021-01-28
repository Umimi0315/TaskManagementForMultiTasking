using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TaskManagementForMultiTasking
{
    public partial class TaskManageForm : Form
    {
        //jar包路径
        private string appiumProject_jarPath = Application.StartupPath + "\\jar\\AppiumForSmartHome.jar";
        //方法映射文件位置
        private string methodsMapping_Path = Application.StartupPath + "\\MethodMapping\\MethodsMapping.xml";

        public TaskManageForm()
        {
            InitializeComponent();
            this.taskInfoDataGridView.AutoGenerateColumns = true;
            TaskInfoDataGridViewOpt.updateTaskInfoDataGridView(this.taskInfoDataGridView);
        }

        
        //刷新表格数据
        private void refreshTaskBtn_Click(object sender, EventArgs e)
        {
            TaskInfoDataGridViewOpt.updateTaskInfoDataGridView(this.taskInfoDataGridView);
        }

        //创建任务
        private void taskCreateBtn_Click(object sender, EventArgs e)
        {
            TaskCreateForm taskCreateForm = new TaskCreateForm(this.taskInfoDataGridView);
            taskCreateForm.ShowDialog();
        }

        //右键菜单
        private void taskInfoDataGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //清空右键菜单的禁用选项
                    for(int i = 0; i < taskOptContextMenuStrip.Items.Count; i++)
                    {
                        this.taskOptContextMenuStrip.Items[i].Enabled = true;
                    }

                    taskInfoDataGridView.ClearSelection();
                    taskInfoDataGridView.Rows[e.RowIndex].Selected = true;
                    taskInfoDataGridView.CurrentCell = taskInfoDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

                    DataGridViewRow selectedTaskInfoDataGridViewRow = this.taskInfoDataGridView.CurrentRow;

                    //禁用右键菜单栏中的某些项
                    if ("激活".Equals(selectedTaskInfoDataGridViewRow.Cells["taskTag"].Value.ToString()))
                    {
                        //激活
                        this.taskOptContextMenuStrip.Items["taskActiveToolStripMenuItem"].Enabled = false;
                    }
                    if (!"停止".Equals(selectedTaskInfoDataGridViewRow.Cells["taskStatus"].Value.ToString()))
                    {
                        //修改任务
                        this.taskOptContextMenuStrip.Items["taskNameModifyToolStripMenuItem"].Enabled = false;
                    }
                    if ("停止".Equals(selectedTaskInfoDataGridViewRow.Cells["taskStatus"].Value.ToString()))
                    {
                        //停止任务
                        this.taskOptContextMenuStrip.Items["taskStopToolStripMenuItem"].Enabled = false;
                    }
                    if (!("停止".Equals(selectedTaskInfoDataGridViewRow.Cells["taskStatus"].Value.ToString()) || "新建".Equals(selectedTaskInfoDataGridViewRow.Cells["taskStatus"].Value.ToString())))
                    {
                        //删除任务
                        this.taskOptContextMenuStrip.Items["taskDeleteToolStripMenuItem"].Enabled = false;
                    }
                    if (!"已启动未控".Equals(selectedTaskInfoDataGridViewRow.Cells["taskStatus"].Value.ToString()))
                    {
                        //重新吸附
                        this.taskOptContextMenuStrip.Items["reabsorptionToolStripMenuItem"].Enabled = false;
                    }
                    if ("已启动未控".Equals(selectedTaskInfoDataGridViewRow.Cells["taskStatus"].Value.ToString()) || "已启动已控".Equals(selectedTaskInfoDataGridViewRow.Cells["taskStatus"].Value.ToString())||"普通".Equals(selectedTaskInfoDataGridViewRow.Cells["taskTag"].Value.ToString()))
                    {
                        //启动任务
                        this.taskOptContextMenuStrip.Items["taskStartToolStripMenuItem"].Enabled = false;
                    }

                    taskOptContextMenuStrip.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        //修改任务
        private void taskNameModifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //弹出激活窗口
            TaskNameModifyForm taskNameModifyForm = new TaskNameModifyForm(this.taskInfoDataGridView);
            taskNameModifyForm.ShowDialog();
        }

        //激活任务
        private void taskActiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = null;
            try
            {
                conn=DatabaseOpt.getDBConnection();
                List<string> taskIdList = DatabaseOpt.queryTaskTag(conn);
                if (taskIdList.Count > 0)
                {
                    //显示弹窗
                    ActiveConfirmForm activeConfirmForm = new ActiveConfirmForm(taskIdList);
                    activeConfirmForm.ShowDialog();
                }

                if (!taskIdList.Contains("cancel"))
                {

                    //激活任务代码
                    //通知web端本条任务激活
                    string phoneNumber = this.taskInfoDataGridView.CurrentRow.Cells["phoneNumber"].Value.ToString();
                    string IMSI = this.taskInfoDataGridView.CurrentRow.Cells["IMSI"].Value.ToString();
                    string nationCode = this.taskInfoDataGridView.CurrentRow.Cells["nationCode"].Value.ToString();

                    string url = "http://47.96.5.240:8989/ghost/getVerificationCode?imsi="+IMSI+"&phone="+phoneNumber+"&phone_nation_code="+nationCode;
                    string responseContent=WebServerCommunicate.httpGet(url);
                    if (!"ok".Equals(responseContent))
                    {
                        MessageBox.Show("激活失败");
                        return;
                    }

                    //修改任务标志
                    string taskId = this.taskInfoDataGridView.CurrentRow.Cells["taskId"].Value.ToString();
                    DatabaseOpt.updateOne(conn, taskId, "taskTag", "激活");

                }
            }catch(Exception)
            {
                MessageBox.Show("发生错误,激活失败");
            }
            finally
            {
                DatabaseOpt.close(conn);
                TaskInfoDataGridViewOpt.updateTaskInfoDataGridView(this.taskInfoDataGridView);
            }
        }

        //启动任务
        private void taskStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //开启线程运行启动任务的实现方法
            Thread extrationThread = new Thread(new ParameterizedThreadStart(taskStart));
            extrationThread.Start(this.taskInfoDataGridView.CurrentRow);
        }

        //停止任务
        private void taskStopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //获取本模拟器的编号通过命令行停止,关闭appium和socket连接



            //修改任务状态和任务标志
            string taskId=this.taskInfoDataGridView.CurrentRow.Cells["taskId"].Value.ToString();
            MySqlConnection conn=DatabaseOpt.getDBConnection();
            DatabaseOpt.updateOne(conn, taskId, "taskStatus", "停止");
            DatabaseOpt.updateOne(conn, taskId, "taskTag", "普通");
            DatabaseOpt.close(conn);
            TaskInfoDataGridViewOpt.updateTaskInfoDataGridView(this.taskInfoDataGridView);
        }

        //删除任务
        private void taskDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //获取本模拟器的编号并通过命令行删除,关闭appium和socket连接


            //删除该条任务信息
            string taskId=this.taskInfoDataGridView.CurrentRow.Cells["taskId"].Value.ToString();
            MySqlConnection conn=DatabaseOpt.getDBConnection();
            DatabaseOpt.deleteOne(conn,taskId);
            DatabaseOpt.close(conn);
            TaskInfoDataGridViewOpt.updateTaskInfoDataGridView(this.taskInfoDataGridView);

        }

        //重新吸附
        private void reabsorptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //判断条件


            //修改任务标记
            string taskId = this.taskInfoDataGridView.CurrentRow.Cells["taskId"].Value.ToString();
            MySqlConnection conn=DatabaseOpt.getDBConnection();
            DatabaseOpt.updateOne(conn, taskId, "taskTag", "激活");
            DatabaseOpt.close(conn);
            TaskInfoDataGridViewOpt.updateTaskInfoDataGridView(this.taskInfoDataGridView);
        }


        //将待测APP名与取证主函数名对应
        public string MethodMapping(string itemName)
        {
            XmlDocument document = new XmlDocument();
            document.Load(methodsMapping_Path);
            XmlNodeList xmlNodeList = document.SelectNodes("//MethodsMapping//MethodsMappingItem[ItemName='" + itemName + "']");
            if (xmlNodeList.Count == 0)
            {
                return null;
            }
            return xmlNodeList[0].LastChild.InnerText;
        }

        //启动任务的实现方法
        public void taskStart(Object row)
        {
            MySqlConnection conn = null;
            int appiumPort = 0;

            DataGridViewRow currentRow = (DataGridViewRow)row;

            //选中任务的id
            string taskId = currentRow.Cells["taskId"].Value.ToString();

            MessageBox.Show(taskId);

            try
            {
                conn = DatabaseOpt.getDBConnection();

                List<string> emulatorIdList = DatabaseOpt.queryOne(conn, taskId, "emulatorId");
                //说明该任务还没有创建模拟器
                if ("".Equals(emulatorIdList[0]))
                {
                    //创建模拟器
                    int emulatorId = EmulatiorOpt.createEmu();
                    //计算端口号
                    int emulatorPort = 21503 + emulatorId * 10;

                    //将新建信息插入数据库
                    DatabaseOpt.updateOne(conn, taskId, "emulatorId", emulatorId.ToString());
                    DatabaseOpt.updateOne(conn, taskId, "emulatorPort", emulatorPort.ToString());
                }

                //获取当前任务的模拟器号和端口
                string emulatorIdStr = DatabaseOpt.queryOne(conn, taskId, "emulatorId")[0];
                string emulatorPortStr = DatabaseOpt.queryOne(conn, taskId, "emulatorPort")[0];

                //启动模拟器
                EmulatiorOpt.startEmu(emulatorIdStr);

                //设置任务状态为已启动未控
                DatabaseOpt.updateOne(conn, taskId, "taskStatus", "已启动未控");
                TaskInfoDataGridViewOpt.updateTaskInfoDataGridView(this.taskInfoDataGridView);

                //执行安装APP







                //执行启动appium,汇报任务进度
                DatabaseOpt.updateOne(conn, taskId, "taskProgress", "正在初始化appium");
                TaskInfoDataGridViewOpt.updateTaskInfoDataGridView(this.taskInfoDataGridView);

                appiumPort = AppiumOpt.getAvailablePort(4723, 65534);
                //说明appium无可用端口
                if (appiumPort == 0)
                {
                    //将该条任务在数据库中的appiumPort值置为""
                    DatabaseOpt.updateOne(conn, taskId, "appiumPort", "");
                    DatabaseOpt.updateOne(conn, taskId, "taskProgress", "appium无可用端口");
                    TaskInfoDataGridViewOpt.updateTaskInfoDataGridView(this.taskInfoDataGridView);
                    return;
                }
                else
                {
                    //记录本次启动任务使用的appium端口号
                    DatabaseOpt.updateOne(conn, taskId, "appiumPort", appiumPort.ToString());
                }

                //开启appium服务
                AppiumOpt.callCmd("appium -a 127.0.0.1 -p " + appiumPort);

                //睡眠5秒等待appium开启
                Thread.Sleep(5000);

                int socketPort = AppiumOpt.getAvailablePort(50000, 65534);
                //说明socket无可用端口
                if (socketPort == 0)
                {
                    //将该条任务在数据库中的socketPort值置为""
                    DatabaseOpt.updateOne(conn, taskId, "socketPort", "");
                    DatabaseOpt.updateOne(conn, taskId, "taskProgress", "socket通信无可用端口");
                    TaskInfoDataGridViewOpt.updateTaskInfoDataGridView(this.taskInfoDataGridView);
                    return;
                }
                else
                {
                    //记录本次启动任务使用的socket端口号
                    DatabaseOpt.updateOne(conn, taskId, "socketPort", socketPort.ToString());
                }


                //准备调用jar包所需要传入的参数
                string appName = currentRow.Cells["appName"].Value.ToString();
                string methodName = MethodMapping(appName);
                string deviceName = "127.0.0.1:" + emulatorPortStr;

                string IMSI = currentRow.Cells["IMSI"].Value.ToString();
                string phoneNumber = currentRow.Cells["phoneNumber"].Value.ToString();
                string nationCode = currentRow.Cells["nationCode"].Value.ToString();

                //开启线程运行jar包
                Thread extrationThread = new Thread(new ParameterizedThreadStart(AppiumOpt.callCmd));
                extrationThread.Start("java -cp" + " " + @appiumProject_jarPath + " " + methodName + " " + "127.0.0.1 " + socketPort + " " + deviceName + " " + appiumPort + " " + IMSI + " " + phoneNumber + " " + nationCode);

                //与客户端通信
                AppiumOpt.communicate(socketPort, conn, taskId, this.taskInfoDataGridView);


            }
            finally
            {
                //关闭appium端口，清除该任务在数据库中存放的端口信息
                if (appiumPort != 0)
                {
                    AppiumOpt.endAppium(appiumPort);
                }
                if (conn != null)
                {
                    DatabaseOpt.updateOne(conn, taskId, "appiumPort", "");
                    DatabaseOpt.updateOne(conn, taskId, "socketPort", "");
                }

                DatabaseOpt.close(conn);
            }
        }

    }
}
