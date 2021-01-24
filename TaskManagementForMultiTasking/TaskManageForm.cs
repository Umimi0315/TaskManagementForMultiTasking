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
using System.Xml;

namespace TaskManagementForMultiTasking
{
    public partial class TaskManageForm : Form
    {
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
    }
}
