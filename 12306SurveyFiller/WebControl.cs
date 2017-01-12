using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace SurveyFiller
{
    public sealed class WebControl
    {
        private static WebControl _instance;
        private CookieCollection COOKIES = new CookieCollection();
        CookieContainer co;

        private WebControl()
        {
            System.Net.ServicePointManager.Expect100Continue = false;
            co = new CookieContainer();
        }

        public static WebControl Instance()
        {
            if (_instance == null)
            {
                _instance = new WebControl();
            }

            return _instance;
        }

        public String PostHttpRequest(String URL, String postdata)
        {
            HttpWebRequest request = WebRequest.Create(URL) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = @"Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.1.6) Gecko/20091201 Firefox/3.5.6";
            request.KeepAlive = true;
            request.ContentType = "application/x-www-form-urlencoded";
            //request.ContentLength = postdata.Length;
            request.Referer = @"http://dynamic.12306.cn/surweb/questionnaireAction.do?method=surveyNote";
            request.Accept = @"application/json, text/javascript, */*";
            request.CookieContainer = co;
            try
            {
                byte[] data = Encoding.Default.GetBytes(postdata);
                Stream stream = request.GetRequestStream();
                stream.Write(data, 0, data.Length);
                stream.Close();
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                COOKIES = response.Cookies;
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("UTF-8"));
                string st = reader.ReadToEnd();
                response.Close();
                return st;
            }
            catch (Exception e)
            {
                return "E[可重试]" + e.Message;
            }
        }

        public Dictionary<String, String> GetStationList()
        {
            Dictionary<String, String> dict = new Dictionary<string, string>();
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
                String st = PostHttpRequest("http://kyfw.12306.cn/otn/resources/js/framework/station_name.js", "");
                st = st.Split('\'')[1];
                String[] result = st.Split('@');

                foreach (String station in result)
                {
                    String[] temp = station.Split('|');
                    if (temp.Length > 3)
                    {
                        dict.Add(temp[1], temp[2]);
                    }
                }
                return dict;
            }
            catch (Exception ex) { return dict; }
        }
        public String PostSurvey(String postData)
        {
            String st = PostHttpRequest("http://dynamic.12306.cn/surweb/questionnaireAction.do?method=submitQuest", postData);
            if (st[0] == '0')
            {
                return st;
            }
            else
            {
                try
                {
                    int surveyNoStart = st.IndexOf("surveyNo\" value=") + 17;
                    if (surveyNoStart != 16)
                    {
                        return "S" + st.Substring(surveyNoStart, 10);
                    }
                    else
                    {
                        int msgStart = st.IndexOf("message = \"") + 11;
                        st = st.Substring(msgStart);
                        int msgEnd = st.IndexOf('"');
                        st = st.Substring(0, msgEnd);
                        if (st == "") { return "E[可重试]问卷系统未知错误"; }
                        return "E" + st;
                    }
                }
                catch (Exception e)
                {
                    string reason = e.ToString();
                    return "E" + reason.Substring(0, reason.IndexOf('\n') - 1);
                }
            }
        }

        private static bool RemoteCertificateValidate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {
            return true;
        }

    }
}
