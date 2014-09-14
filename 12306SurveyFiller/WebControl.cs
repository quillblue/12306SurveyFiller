using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace SurveyFiller
{
    public class WebControl
    {
        public WebControl()
        {
            System.Net.ServicePointManager.Expect100Continue = false;
        }

        public String PostHttpRequest(String URL, String postdata)
        {
            CookieContainer co = new CookieContainer();
            HttpWebRequest request = WebRequest.Create(URL) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = @"Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.1.6) Gecko/20091201 Firefox/3.5.6";
            request.KeepAlive = true;
            request.Referer = @"http://www.12306.cn/";
            request.Accept = @"text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.CookieContainer = co;
            try
            {
                byte[] data = Encoding.Default.GetBytes(postdata);
                Stream stream = request.GetRequestStream();
                stream.Write(data, 0, data.Length);
                stream.Close();
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("UTF-8"));
                string st = reader.ReadToEnd();
                response.Close();
                return st;
            }
            catch (Exception e)
            {
                return "0#" + e.Message;
            }
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
                        return "1#" + st.Substring(surveyNoStart, 10);
                    }
                    else
                    {
                        int msgStart = st.IndexOf("message = \"") + 11;
                        st = st.Substring(msgStart);
                        int msgEnd = st.IndexOf('"');
                        st = st.Substring(0, msgEnd);
                        if (st == "") { return "0#-21180"; }
                        return "0#" + st;
                    }
                }
                catch (Exception e)
                {
                    string reason = e.ToString();
                    return "0#" + reason.Substring(0, reason.IndexOf('\n') - 1);
                }
            }
        }

    }
}
