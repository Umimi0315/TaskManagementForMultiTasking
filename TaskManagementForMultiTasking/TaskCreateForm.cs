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
    public partial class TaskCreateForm : Form
    {
        DataGridView taskInfoDataGridView;
        public TaskCreateForm(DataGridView taskInfoDataGridView)
        {
            InitializeComponent();
            this.taskInfoDataGridView = taskInfoDataGridView;
        }

        //创建任务按钮
        private void taskCreateBtn_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = null;

            try
            {
                if (appNameListView.SelectedItems.Count != 1)
                {
                    MessageBox.Show("请选择一个待执行的APP");
                    return;
                }

                if ("".Equals(apkPathTextBox.Text))
                {
                    MessageBox.Show("APK安装路径不能为空");
                    return;
                }

                if ("".Equals(taskNameText.Text))
                {
                    MessageBox.Show("任务名不能为空");
                    return;
                }
                if ("".Equals(IMSIText.Text))
                {
                    MessageBox.Show("IMSI不能为空");
                    return;
                }
                if ("".Equals(phoneNumberText.Text))
                {
                    MessageBox.Show("手机号不能为空");
                    return;
                }
                if ("".Equals(nationCodeTextBox.Text))
                {
                    MessageBox.Show("国家编码不能为空");
                    return;
                }

                string appName = appNameListView.SelectedItems[0].Text;
                string apkPath = apkPathTextBox.Text;
                apkPath = apkPath.Replace(@"\",@"\\");
                string taskName = taskNameText.Text;
                string IMSI = IMSIText.Text;
                string phoneNumber = phoneNumberText.Text;
                string nationCode = nationCodeTextBox.Text;

                string taskCreateTime = DateTime.Now.ToString();
                string appPackageName = appNameListView.SelectedItems[0].Tag.ToString();

                TaskInfo taskInfo = new TaskInfo(taskName,phoneNumber,IMSI,nationCode,appName,taskCreateTime,"新建","普通",apkPath,appPackageName,"无");
                
                conn= DatabaseOpt.getDBConnection();
                DatabaseOpt.insertOne(conn, taskInfo);
                
                TaskInfoDataGridViewOpt.updateTaskInfoDataGridView(taskInfoDataGridView);
            }
            finally
            {
                DatabaseOpt.close(conn);
                this.Dispose();
            }


        }

        //选择apk路径按钮
        private void apkPathBtn_Click(object sender, EventArgs e)
        {
            this.apkPathOpenFileDialog.ShowDialog();
            this.apkPathOpenFileDialog.Dispose();
            this.apkPathTextBox.Text = this.apkPathOpenFileDialog.FileName;
        }

        //取消按钮
        private void taskCancelBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        //x号
        private void TaskCreateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
