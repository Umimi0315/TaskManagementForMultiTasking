﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TaskManagementForMultiTasking
{
    public static class DatabaseOpt
    {
        private static string dbconfigPath= Application.StartupPath + "\\config\\dbconfig.xml";

        public static MySqlConnection getDBConnection()
        {
            XmlDocument dbconfigDoc = new XmlDocument();
            dbconfigDoc.Load(dbconfigPath);


            //读取xml中配置的数据库设置
            string dataSource = dbconfigDoc.SelectSingleNode("//DatabaseConfig/param[@name='DataSource']").InnerText;
//            string port= dbconfigDoc.SelectSingleNode("//DatabaseConfig/param[@name='port']").InnerText;
            string databaseName= dbconfigDoc.SelectSingleNode("//DatabaseConfig/param[@name='DatabaseName']").InnerText;
            string username= dbconfigDoc.SelectSingleNode("//DatabaseConfig/param[@name='username']").InnerText;
            string password= dbconfigDoc.SelectSingleNode("//DatabaseConfig/param[@name='password']").InnerText;

            //建立连接
            string connStr = "Data Source=" + dataSource + ";Database=" + databaseName + ";User Id=" + username + ";Password=" + password;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                return conn;
            }
            catch (Exception e)
            {
                MessageBox.Show("数据库连接出错！");
            }

            return null;
        }

        public static void close(MySqlConnection conn)
        {
            if (conn != null)
            {
                conn.Close();
            }
        }

        //查询全部任务
        public static DataTable queryAll(MySqlConnection conn)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter("select * from task_info_table", conn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        //插入一条数据
        public static int insertOne(MySqlConnection conn, TaskInfo task)
        {
            string sql = "insert into task_info_table(taskName,phoneNumber,IMSI,appName,taskCreateTime,taskStatus,taskTag,taskProgress,nationCode,appPackageName,apkPath)" +
                "values('" + task.TaskName + "','" + task.PhoneNumber + "','" + task.IMSI1 + "','" + task.AppName + "','" + task.TaskCreateTime + "','" + task.TaskStatus + "','" + task.TaskTag + "','" + task.TaskProgress + "','" + task.NationCode + "','" + task.AppPackageName + "','" + task.ApkPath + "')";
            MySqlCommand command = new MySqlCommand(sql, conn);
            int result=command.ExecuteNonQuery();
            return result;
        }


    }
}