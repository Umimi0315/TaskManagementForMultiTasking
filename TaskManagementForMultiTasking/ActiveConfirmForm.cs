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
            MySqlConnection conn = DatabaseOpt.getDBConnection();
            //将已激活任务置为普通
            for(int i = 0; i < taskIdList.Count; i++)
            {
                string taskId = taskIdList[i];
                DatabaseOpt.updateOne(conn, taskId, "taskTag", "普通");
                //停止任务的代码





            }
            DatabaseOpt.close(conn);

            this.Dispose();
        }
    }
}
