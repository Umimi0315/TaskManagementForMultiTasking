using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementForMultiTasking
{
    public class TaskInfo
    {
        private int taskId;
        private string taskName;
        private string phoneNumber;
        private string IMSI;
        private string nationCode;
        private string appName;
        private string taskCreateTime;
        private string taskStatus;
        private string taskTag;
        private string taskProgress="";
        private string apkPath;
        private string appPackageName;

        public TaskInfo()
        {

        }

        public TaskInfo(string taskName,string phoneNumber,string IMSI,string nationCode,string appName,string taskCreateTime,string taskStatus,string taskTag,string apkPath,string appPackageName,string taskProgress)
        {
            this.taskName = taskName;
            this.phoneNumber = phoneNumber;
            this.IMSI = IMSI;
            this.nationCode = nationCode;
            this.appName = appName;
            this.taskCreateTime = taskCreateTime;
            this.taskStatus = taskStatus;
            this.taskTag = taskTag;
            this.apkPath = apkPath;
            this.appPackageName = appPackageName;
            this.taskProgress = taskProgress;
        }

        public string TaskName { get => taskName; set => taskName = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string IMSI1 { get => IMSI; set => IMSI = value; }
        public string AppName { get => appName; set => appName = value; }
        public string TaskCreateTime { get => taskCreateTime; set => taskCreateTime = value; }
        public string TaskStatus { get => taskStatus; set => taskStatus = value; }
        public string TaskTag { get => taskTag; set => taskTag = value; }
        public int TaskId { get => taskId; set => taskId = value; }
        public string TaskProgress { get => taskProgress; set => taskProgress = value; }
        public string NationCode { get => nationCode; set => nationCode = value; }
        public string ApkPath { get => apkPath; set => apkPath = value; }
        public string AppPackageName { get => appPackageName; set => appPackageName = value; }
    }
}
