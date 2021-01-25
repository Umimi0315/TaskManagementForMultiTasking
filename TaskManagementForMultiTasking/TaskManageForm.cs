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

        //右键菜单
        private void taskInfoDataGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    taskInfoDataGridView.ClearSelection();
                    taskInfoDataGridView.Rows[e.RowIndex].Selected = true;
                    taskInfoDataGridView.CurrentCell = taskInfoDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    taskOptContextMenuStrip.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        //修改任务
        private void taskNameModifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //判断条件


            //弹出激活窗口
            TaskNameModifyForm taskNameModifyForm = new TaskNameModifyForm(this.taskInfoDataGridView);
            taskNameModifyForm.ShowDialog();
        }

        //激活任务
        private void taskActiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //判断条件


            //修改任务标志
            string taskId= this.taskInfoDataGridView.CurrentRow.Cells["taskId"].Value.ToString();
            MySqlConnection conn=DatabaseOpt.getDBConnection();
            DatabaseOpt.updateOne(conn, taskId, "taskTag", "激活");
            DatabaseOpt.close(conn);
            TaskInfoDataGridViewOpt.updateTaskInfoDataGridView(this.taskInfoDataGridView);
        }

        //任务开始
        private void taskStartToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //任务停止
        private void taskStopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //判断条件


            //修改任务状态和任务标志
            string taskId=this.taskInfoDataGridView.CurrentRow.Cells["taskId"].Value.ToString();
            MySqlConnection conn=DatabaseOpt.getDBConnection();
            DatabaseOpt.updateOne(conn, taskId, "taskStatus", "停止");
            DatabaseOpt.updateOne(conn, taskId, "taskTag", "普通");
            DatabaseOpt.close(conn);
            TaskInfoDataGridViewOpt.updateTaskInfoDataGridView(this.taskInfoDataGridView);
        }

        //任务删除
        private void taskDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //判断条件


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
    }
}
