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

        //获取数据库连接
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
            catch (Exception)
            {
                MessageBox.Show("数据库连接出错！");
            }

            return null;
        }

        //关闭数据库连接
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

        //更新一条数据的某个字段
        public static int updateOne(MySqlConnection conn,string taskId,string fieldName,string value)
        {
            string sql = "update task_info_table set " + fieldName + "='" + value + "' where taskId=" + taskId;
            MySqlCommand command = new MySqlCommand(sql, conn);
            int result=command.ExecuteNonQuery();
            return result;
        }

        //删除一条数据
        public static int deleteOne(MySqlConnection conn, string taskId)
        {
            string sql = "delete from task_info_table where taskId="+taskId;
            MySqlCommand command = new MySqlCommand(sql,conn);
            int result = command.ExecuteNonQuery();
            return result;
        }

        //查询标志为激活的任务id
        public static List<string> queryTaskTag(MySqlConnection conn)
        {
            MySqlDataReader reader = null;
            try
            {
                List<string> taskIdList = new List<string>();
                string sql = "select taskId from task_info_table where taskTag='激活'";
                MySqlCommand command = new MySqlCommand(sql, conn);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string taskId = reader["taskId"].ToString();
                    taskIdList.Add(taskId);
                }
                return taskIdList;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }

        }

        //查询某条任务信息某个字段的值
        public static List<string> queryOne(MySqlConnection conn,string taskId,string fieldName)
        {
            MySqlDataReader reader = null;
            try
            {
                List<string> taskFieldValueList = new List<string>();
                string sql = "select "+fieldName+ " from task_info_table where taskId="+taskId;
                MySqlCommand command = new MySqlCommand(sql, conn);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string taskFieldValue = reader[fieldName].ToString();
                    taskFieldValueList.Add(taskFieldValue);
                }
                return taskFieldValueList;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

    }
}
