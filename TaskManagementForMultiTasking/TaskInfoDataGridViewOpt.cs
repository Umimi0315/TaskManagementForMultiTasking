﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManagementForMultiTasking
{
    public static class TaskInfoDataGridViewOpt
    {
        public static void updateTaskInfoDataGridView(DataGridView taskInfoDataGridView)
        {
            DataTable dt = (DataTable)taskInfoDataGridView.DataSource;
            if (dt != null)
            {
                dt.Rows.Clear();
                taskInfoDataGridView.DataSource = dt;
            }
            MySqlConnection conn = DatabaseOpt.getDBConnection();
            taskInfoDataGridView.DataSource = DatabaseOpt.queryAll(conn);

        }
    }
}