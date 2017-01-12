using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace SurveyFiller
{
    public class ValidationCodeProcessing
    {
        WebControl wc = WebControl.Instance();
        public String FetchValidationCode(String userName)
        {
            String PostData = "userName=" + userName + "&oldUserName=" + userName;
            String response = wc.PostHttpRequest("http://dynamic.12306.cn/surweb/registAction.do?method=sendSm", PostData);
            //String response = "{\"mn\":\"130****0000\",\"resultCode\":\"ok\",\"resultData\":\"8715\"}";

            String ResultCode = "";
            String Seq_No = "";
            if (response[0] == 'E') { return response.Substring(1); }
            try
            {
                JsonReader reader = new JsonTextReader(new StringReader(response));
                while (reader.Read())
                {
                    if (reader.Path == "resultCode")
                    {
                        ResultCode = reader.Value.ToString();
                    }
                    if (reader.Path == "resultData")
                    {
                        Seq_No = reader.Value.ToString();
                    }
                }
                if (ResultCode == "ok") { return Seq_No; }
                else
                {
                    if (ResultCode == "busFail") { return "请求验证码的频率达到设定上限,待重试"; }
                    else { return ErrorCodeTranslation(ResultCode); }
                }
            }
            catch (Exception e)
            {
                return "[可重试]SystemError:" + e.Message;
            }
        }

        public String SendValidationRequest(string userName, string seq_result, string vcInput)
        {
            String result = "";
            result = SendValidationCode(userName, seq_result, vcInput);
            return (result == "ok") ? "ok" : ErrorCodeTranslation(result);
        }

        private String SendValidationCode(String userName, String seq_no, String validationCode)
        {
            String PostData = "userName=" + userName + "&vc=" + validationCode + "&seq_no=" + seq_no;
            String response = wc.PostHttpRequest("http://dynamic.12306.cn/surweb/registAction.do?method=checkVc", PostData);
            String ResultCode = "";
            String ResultData = "";
            JsonReader reader = new JsonTextReader(new StringReader(response));
            try
            {
                while (reader.Read())
                {
                    if (reader.Path == "resultCode")
                    {
                        ResultCode = reader.Value.ToString();
                    }
                    if (reader.Path == "resultData")
                    {
                        ResultData = reader.Value.ToString();
                    }
                }
                return ResultCode == "busFail" ? ResultData : ResultCode;
            }
            catch (Exception e)
            {
                return "[可重试]SystemError:" + e.Message;
            }
        }

        private String ErrorCodeTranslation(String errorCode)
        {
            String translation = "";
            switch (errorCode)
            {
                case "fail": translation = "当前用户过多或验证码输入错误"; break;
                case "uName_error": translation = "用户名不正确"; break;
                case "session_timeout": translation = "当前验证码已过期"; break;
                case "system_unknownError": translation = "问卷系统异常"; break;
                default: translation = errorCode + "（仅供参考）"; break;
            }
            return translation;
        }
    }
}
