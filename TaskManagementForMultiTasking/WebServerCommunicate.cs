using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementForMultiTasking
{
    public static class WebServerCommunicate
    {
        public static string httpGet(string url)
        {
            StreamReader reader = null;
            try
            {
                //创建
                HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                //设置请求方法
                httpWebRequest.Method = "GET";
                //请求超时时间
                httpWebRequest.Timeout = 20000;
                //发送请求
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                //利用Stream流读取返回数据
                reader = new StreamReader(httpWebResponse.GetResponseStream());
                //获得最终数据，一般是JSON
                string responseContent = reader.ReadToEnd();

                return responseContent;
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
