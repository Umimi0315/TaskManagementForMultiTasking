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
    public partial class TaskNameModifyForm : Form
    {
        DataGridView taskDataGridView;
        public TaskNameModifyForm(DataGridView taskDataGridView)
        {
            InitializeComponent();
            this.taskDataGridView = taskDataGridView;
            this.taskNameModifyTextBox.Text = taskDataGridView.CurrentRow.Cells["taskName"].Value.ToString();
        }

        //取消按钮
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        //x号
        private void TaskNameModifyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        //确定按钮
        private void confirmBtn_Click(object sender, EventArgs e)
        {
            string newTaskName = this.taskNameModifyTextBox.Text;
            string taskId = taskDataGridView.CurrentRow.Cells["taskId"].Value.ToString();
            MySqlConnection conn = DatabaseOpt.getDBConnection();
            DatabaseOpt.updateOne(conn, taskId, "taskName", newTaskName);
            DatabaseOpt.close(conn);
            TaskInfoDataGridViewOpt.updateTaskInfoDataGridView(this.taskDataGridView);
            this.Dispose();
        }
    }
}
