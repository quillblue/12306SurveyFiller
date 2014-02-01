using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace SurveyFiller
{
    public class WebControl
    {
        public WebControl()
        {
            System.Net.ServicePointManager.Expect100Continue = false;
        }
        public String PostRequest(String URL, String postData)
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
                byte[] data = Encoding.Default.GetBytes(postData);
                Stream stream = request.GetRequestStream();
                stream.Write(data, 0, data.Length);
                stream.Close();
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("UTF-8"));
                string st = reader.ReadToEnd();
                response.Close();
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
                return "0#" + reason.Substring(0, reason.IndexOf('\n')-1);
            }
        }

        public String FillSurvey(SurveyBaseInfo sbi, int option)
        {
            if (sbi.TravelRecord.OnBoardStation[0] == '#')
            {
                return "0#票面乘车站" + sbi.TravelRecord.OnBoardStation.Substring(1) + "未能被翻译为电报码，请检查站名是否准确\n";
            }
            if (sbi.TravelRecord.OffBoardStation[0] == '#')
            {
                return "0#票面下车站" + sbi.TravelRecord.OffBoardStation.Substring(1) + "未能被翻译为电报码，请检查站名是否准确\n";
            }
            String passengerInfoAnswer = sbi.WrapSurveyBaseInfo();
            String questionRadioAnswer = "";
            if (option==0)
            {
                questionRadioAnswer = "{1:007,2:027,3:007,4:007,5:007,6:074,7:037,8:017,9:017,10:017,11:007,12:007,13:017,14:037,15:017,16:127,17:057,18:017,19:007,20:017,21:017,22:017,23:017,24:017,25:007,26:017,27:017,28:017,29:017,30:017,31:017,32:017,33:017,34:017,35:057,36:087,37:017,38:017,39:017,40:017,41:007,42:017,43:017,44:017,45:017,46:017,47:017,48:017,49:017,50:007,51:017,52:017,53:017,54:017,55:017,56:017,57:017,58:017,59:017,60:017,61:017,62:017,63:017,64:017,65:087,66:057,67:017,68:017,69:017,70:097,71:017,72:017,73:017,74:017,75:017,76:067,77:117,101:225,102:204,103:207,104:227,105:213}";
            }
            else
            {
                questionRadioAnswer = "{1:005,3:005,6:073,7:033,15:004,16:004,17:004,18:004,20:004,21:004,22:004,26:004,30:004,31:004,36:004,37:004,38:004,39:004,40:004,42:015,44:004,45:004,46:004,51:004,52:013,55:013,56:013,63:004,64:004,65:004,66:004,67:004,68:004,70:004,73:004,74:004,75:004,76:004,77:004,101:225,102:202,103:209,104:222,105:213}";
            }
            String otherAnswer = "{78:购票的方便程度/车站的旅客引导信息/进站上车的过程/,79:,80:,81:车票的价格/}";
            String PostData = "passengerInfoAnswer=" + passengerInfoAnswer + "&questionRadioAnswer=" + questionRadioAnswer + "&otherAnswer=" + otherAnswer;
            String msg;
            msg = PostRequest("http://dynamic.12306.cn/surweb/questionnaireAction.do?method=submitQuest", PostData);
            return msg;
        }

    }
}
