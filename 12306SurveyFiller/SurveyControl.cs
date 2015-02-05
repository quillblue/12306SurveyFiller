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
                            Worklist.Add(new SurveyBaseInfo(username, ti));
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

                //UpdateWorkingStatus("读取Excel文件失败，错误原因" + e.ToString(), 2);
            }

            return Worklist;
        }

        public String Output(List<SurveyBaseInfo> successList, List<SurveyBaseInfo> failedList, List<String> resultList)
        {
            //Output Result to Console
            StationNameTranslation snt = new StationNameTranslation();
            snt.LoadDict();
            DateTime CurrentTime = DateTime.Now;
            String Filename = CurrentTime.ToString("yyyy-MM-dd HHmmss") + ".txt";
            FileStream fs = new FileStream(Filename, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding("gb2312"));
            sw.WriteLine("报告打印时间：" + CurrentTime.ToString());
            sw.WriteLine("总条目：" + resultList.Count + "  成功" + successList.Count + "条，失败" + failedList.Count + "条");
            sw.WriteLine("");
            sw.WriteLine("1.问卷填写结果(按Excel中顺序每条一行，成功条目显示问卷号，失败条目显示失败原因)");
            sw.WriteLine("");
            foreach (String i in resultList)
            {
                sw.WriteLine(i);
            }
            sw.WriteLine("");
            sw.WriteLine("===================");
            sw.WriteLine("2.填写成功的问卷列表(可直接复制到Excel)");
            sw.WriteLine("");
            sw.WriteLine("乘车人用户名\t乘车日期\t所乘车次\t票面乘车站\t票面下车站\t问卷编号");
            foreach (SurveyBaseInfo sbi in successList)
            {
                sw.WriteLine(sbi.UserName + "\t" + sbi.TravelRecord.TravelDate + "\t" + sbi.TravelRecord.TravelTrainNumber + "\t" + snt.GetStationName(sbi.TravelRecord.OnBoardStation) + "\t" + snt.GetStationName(sbi.TravelRecord.OffBoardStation) + "\t" + sbi.SurveyNumber);
            }

            sw.WriteLine("");
            sw.WriteLine("===================");
            sw.WriteLine("3.填写失败的问卷列表(可直接复制到Excel)");
            sw.WriteLine("");
            sw.WriteLine("乘车人用户名\t乘车日期\t所乘车次\t票面乘车站\t票面下车站\t失败原因");
            foreach (SurveyBaseInfo sbi in failedList)
            {
                sw.WriteLine(sbi.UserName + "\t" + sbi.TravelRecord.TravelDate + "\t" + sbi.TravelRecord.TravelTrainNumber + "\t" + snt.GetStationName(sbi.TravelRecord.OnBoardStation) + "\t" + snt.GetStationName(sbi.TravelRecord.OffBoardStation) + "\t" + sbi.SurveyNumber);
            }

            sw.Close();
            fs.Close();
            return Filename;
        }

        public String FillSurvey(SurveyBaseInfo sbi, int option)
        {
            if (snt.GetTelegramCode(sbi.TravelRecord.OnBoardStation) == null)
            {
                return "票面上车站" + sbi.TravelRecord.OnBoardStation + "未能被翻译为电报码，请检查\n";
            }
            if (snt.GetTelegramCode(sbi.TravelRecord.OffBoardStation) == null)
            {
                return "票面下车站" + sbi.TravelRecord.OffBoardStation + "未能被翻译为电报码，请检查\n";
            }
            sbi.TravelRecord.TranslateStation(snt.GetTelegramCode(sbi.TravelRecord.OnBoardStation),snt.GetTelegramCode(sbi.TravelRecord.OffBoardStation));
            String passengerInfoAnswer = sbi.WrapSurveyBaseInfo();
            String questionRadioAnswer = "";
            if (option == 0)
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
            //msg = PostRequest("http://dynamic.12306.cn/surweb/questionnaireAction.do?method=submitQuest", PostData);
            msg = wc.PostSurvey(PostData);
            return msg;
        }
    }
}
