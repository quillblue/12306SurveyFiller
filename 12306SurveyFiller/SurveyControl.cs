using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.IO;

namespace SurveyFiller
{
    public class SurveyControl
    {
        WebControl wc = WebControl.Instance();
        StationNameTranslation snt = new StationNameTranslation();

        public SurveyControl()
        {
            //Load station dictionary
            snt.LoadDict();
        }

        public List<SurveyBaseInfo> LoadWorkList(string filePath)
        {
            List<SurveyBaseInfo> Worklist = new List<SurveyBaseInfo>();
            DataSet ul = new DataSet();

            //Prepare for connection to Excel
            DataSet workListDataset = new DataSet();
            try
            {
                Console.WriteLine("正在读取Excel文件...");
                String sConnectionString = "Provider=Microsoft.Jet.OleDb.4.0;" + "data source=" + filePath + ";Extended Properties='Excel 8.0; HDR=yes; IMEX=0'"; ;
                OleDbConnection objConn = new OleDbConnection(sConnectionString);
                objConn.Open();
                OleDbCommand objCmdSelect = new OleDbCommand("SELECT * FROM [Sheet1$]", objConn);
                OleDbDataAdapter objAdapter = new OleDbDataAdapter();
                objAdapter.SelectCommand = objCmdSelect;
                objAdapter.Fill(workListDataset);
                for (int i = 0; i < workListDataset.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = workListDataset.Tables[0].Rows[i];
                    try
                    {
                        if (dr["乘车日期"].ToString() != "")
                        {
                            TrainInfo ti = new TrainInfo(Convert.ToDateTime(dr["乘车日期"]).ToString("yyyy-MM-dd").Substring(0, 10), dr["所乘车次"].ToString(), dr["票面乘车站"].ToString(), dr["票面下车站"].ToString());
                            String username = dr["用户名"].ToString();
                            ti.TranslateStation(snt.GetTelegramCode(ti.OnBoardStation), snt.GetTelegramCode(ti.OffBoardStation));
                            if (ti.OnBoardStation == null) { Worklist.Add(new SurveyBaseInfo(username, ti, "票面上车站" + ti.OnBoardStationDisplay + "未能被翻译为电报码，请检查")); }
                            else
                            {
                                if (ti.OffBoardStation == null) { Worklist.Add(new SurveyBaseInfo(username, ti, "票面下车站" + ti.OffBoardStationDisplay + "未能被翻译为电报码，请检查")); }
                                else
                                {
                                    Worklist.Add(new SurveyBaseInfo(username, ti));
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        String username = "###";
                        TrainInfo ti = new TrainInfo("###", "###", "###", "###");
                        Worklist.Add(new SurveyBaseInfo(username, ti, "无法识别，" + e.ToString()));
                    }

                }
            }
            catch (Exception e)
            {
            }
            return Worklist;
        }

        public String Output(List<SurveyBaseInfo> workList, String filePath)
        {
            List<SurveyBaseInfo> successList = new List<SurveyBaseInfo>();
            List<SurveyBaseInfo> failedList = new List<SurveyBaseInfo>();
            foreach (SurveyBaseInfo sbi in workList)
            {
                if (sbi.SurveyStatus == "成功") { successList.Add(sbi); }
                if (sbi.SurveyStatus == "失败") { failedList.Add(sbi); }
            }
            DateTime CurrentTime = DateTime.Now;
            try
            {
                FileStream fs = new FileStream(filePath, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding("gb2312"));
                sw.WriteLine("报告打印时间：" + CurrentTime.ToString());
                sw.WriteLine("总条目：" + workList.Count + "  成功" + successList.Count + "条，失败" + failedList.Count + "条");
                sw.WriteLine("");
                sw.WriteLine("1.问卷填写结果(按Excel中顺序每条一行，成功条目显示问卷号，失败条目显示失败原因)");
                sw.WriteLine("");
                foreach (SurveyBaseInfo sbi in workList)
                {
                    sw.WriteLine(sbi.SurveyNumber);
                }
                sw.WriteLine("");
                sw.WriteLine("===================");
                sw.WriteLine("2.填写成功的问卷列表(可直接复制到Excel)");
                sw.WriteLine("");
                sw.WriteLine("乘车人用户名\t乘车日期\t所乘车次\t票面乘车站\t票面下车站\t问卷编号");
                foreach (SurveyBaseInfo sbi in successList)
                {
                    sw.WriteLine(sbi.UserName + "\t" + sbi.TravelRecord.TravelDate + "\t" + sbi.TravelRecord.TravelTrainNumber + "\t" + sbi.TravelRecord.OnBoardStationDisplay + "\t" + sbi.TravelRecord.OffBoardStationDisplay + "\t" + sbi.SurveyNumber);
                }

                sw.WriteLine("");
                sw.WriteLine("===================");
                sw.WriteLine("3.填写失败的问卷列表(可直接复制到Excel)");
                sw.WriteLine("");
                sw.WriteLine("乘车人用户名\t乘车日期\t所乘车次\t票面乘车站\t票面下车站\t失败原因");
                foreach (SurveyBaseInfo sbi in failedList)
                {
                    sw.WriteLine(sbi.UserName + "\t" + sbi.TravelRecord.TravelDate + "\t" + sbi.TravelRecord.TravelTrainNumber + "\t" + sbi.TravelRecord.OnBoardStationDisplay + "\t" + sbi.TravelRecord.OffBoardStationDisplay + "\t" + sbi.SurveyNumber);
                }

                sw.Close();
                fs.Close();
                return "";
            }
            catch (Exception e) { return e.Message; }
        }

        public String FillSurvey(SurveyBaseInfo sbi, int option, String province = "上海/上海")
        {
            String passengerInfoAnswer = sbi.WrapSurveyBaseInfo(province);
            String questionRadioAnswer = "";
            if (option == 0)
            {
                questionRadioAnswer = "{1:007,2:027,3:007,4:007,5:007,6:036,7:007,8:017,9:017,10:007,11:037,12:006,13:056,14:016,15:016,16:016,17:016,18:016,19:007,20:017,21:017,22:017,23:017,24:017,25:017,26:017,27:017,28:017,29:016,30:007,31:016,32:016,33:016,34:016,35:056,36:056,37:017,38:017,39:017,40:017,41:006,42:017,43:017,44:017,45:017,46:016,47:016,48:086,49:017,50:017,51:017,52:067,53:117,54:017,102:205,104:222,105:213,106:231}";
            }
            else
            {
                questionRadioAnswer = "{1:005,2:024,3:004,4:005,5:005,6:035,7:003,8:013,9:013,10:005,11:034,12:005,13:054,14:013,15:014,16:013,17:013,18:013,19:004,20:013,21:015,22:015,23:015,24:013,25:013,26:014,27:015,28:015,29:014,30:003,31:013,32:013,33:014,34:014,35:054,36:053,37:015,38:015,39:016,40:014,41:005,42:013,43:014,44:015,45:015,46:014,47:014,48:084,49:014,50:013,51:014,52:064,53:114,54:014,102:205,104:222,105:213,106:231}";
            }
            String otherAnswer = "{55:购票的方便程度/车站的购票等待时间/列车内的环境卫生/,56:购票的方便程度/车站的购票等待时间/站台的等待秩序/,57:列车内的环境卫生/列车提供用品的补充情况/出站的验票服务/}";
            String PostData = "passengerInfoAnswer=" + passengerInfoAnswer + "&questionRadioAnswer=" + questionRadioAnswer + "&otherAnswer=" + otherAnswer;
            String msg;
            //msg = PostRequest("http://dynamic.12306.cn/surweb/questionnaireAction.do?method=submitQuest", PostData);
            msg = wc.PostSurvey(PostData);
            return msg;
        }
    }
}
