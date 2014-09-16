using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace SurveyFiller
{
    public class ValidationCodeProcessing
    {
        WebControl wc=WebControl.Instance();
        private String FetchValidationCode(String userName)
        {
            String PostData = "userName=" + userName + "&oldUserName=" + userName ;
            String response = wc.PostHttpRequest("http://dynamic.12306.cn/surweb/registAction.do?method=sendSm", PostData);
            //String response = "{\"mn\":\"130****0000\",\"resultCode\":\"ok\",\"resultData\":\"8715\"}";

            String ResultCode = "";
            String Seq_No = "";
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
            else { return "#" + ResultCode; }
        }

        private String SendValidationCode(String userName, String seq_no, String validationCode)
        {
            String PostData = "userName="+userName+"&vc="+validationCode+"&seq_no="+seq_no;
            String response = wc.PostHttpRequest("http://dynamic.12306.cn/surweb/registAction.do?method=checkVc", PostData);
            String ResultCode = "";
            JsonReader reader = new JsonTextReader(new StringReader(response));
            while (reader.Read())
            {
                if (reader.Path == "resultCode")
                {
                    ResultCode = reader.Value.ToString();
                }
            }
            return ResultCode;
        }

        private String ErrorCodeTranslation(String errorCode) 
        {
            String translation = "";
            switch (errorCode) 
            {
                case "fail": translation = "当前用户过多或验证码输入错误";break;
                case "uName_error": translation = "用户名不正确"; break;
                case "session_timeout": translation = "当前验证码已过期"; break;
                default: translation = "验证过程中出现未知错误"; break;
            }
            return "0#" + translation;
        }

        public String Validation(string userName)
        {
            String seq_result = "";
            for (int i = 0; i < 20 && (seq_result.Length != 4); i++)
            {
                seq_result = FetchValidationCode(userName);
            }
            if (seq_result.Length != 4) 
            {
                return ErrorCodeTranslation(seq_result);
            }
            Console.WriteLine("正在进行手机验证，请在15分钟内输入"+userName+"手机上收到的验证码，本次验证序列号为"+seq_result);

                String vcInput = Console.ReadLine();
                String result = "";
                for (int i = 0; i < 20 && (result != "ok"); i++)
                {
                    result = SendValidationCode(userName, seq_result, vcInput);
                    if (result == "fail")
                    {
                        Console.WriteLine("验证码输入错误");
                        break;
                    }
                }

            
            return (result == "ok" ? "" : "0#") + result;
        }
    }
}
