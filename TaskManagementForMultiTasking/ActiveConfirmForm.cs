using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManagementForMultiTasking
{
    public partial class ActiveConfirmForm : Form
    {
        public List<string> taskIdList;
        public ActiveConfirmForm(List<string> taskIdList)
        {
            InitializeComponent();
            this.taskIdList = taskIdList;
        }

        //否按钮
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            taskIdList.Add("cancel");
            this.Dispose();
        }

        //是按钮
        private void confirmBtn_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = null;

            try
            {
                conn = DatabaseOpt.getDBConnection();
                //将已激活任务置为普通
                for(int i = 0; i < taskIdList.Count; i++)
                {
                    string taskId = taskIdList[i];
                    //停止任务的代码
                    //查询并停止模拟器
                    string emualtorId = DatabaseOpt.queryOne(conn, taskId, "emulatorId")[0];
                    if (!"".Equals(emualtorId))
                    {
                        //说明模拟器已创建，通过命令行停止
                        EmulatiorOpt.shutdownEmu(emualtorId);
                    }
                    string appiumPort = DatabaseOpt.queryOne(conn, taskId, "appiumPort")[0];
                    if (!"".Equals(appiumPort))
                    {
                        //说明appium已经启动，通过命令行杀死
                        AppiumOpt.endAppium(int.Parse(appiumPort));
                    }
                    string socketPort = DatabaseOpt.queryOne(conn, taskId, "socketPort")[0];
                    if (!"".Equals(socketPort))
                    {
                        //说明socket已经开启，通过命令行杀死
                        AppiumOpt.endAppium(int.Parse(socketPort));
                    }

                    DatabaseOpt.updateOne(conn, taskId, "taskTag", "普通");
                    DatabaseOpt.updateOne(conn, taskId, "taskStatus", "停止");
                }
            }
            finally
            {
                DatabaseOpt.close(conn);
                this.Dispose();
            }

        }
    }
}
