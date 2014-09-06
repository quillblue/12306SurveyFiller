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
        public List<SurveyBaseInfo> LoadWorkList(string filePath, string accountConfigPath)
        {
            List<SurveyBaseInfo> Worklist = new List<SurveyBaseInfo>();
            Dictionary<String, UserInfo> AccountDict = new Dictionary<string, UserInfo>();
            DataSet ul = new DataSet();
            #region ReadAccountConfig
            try
            {
                Console.WriteLine("正在读取12306账户信息...");
                String sUserConnectionString = "Provider=Microsoft.Jet.OleDb.4.0;" + "data source=" + accountConfigPath + ";Extended Properties='Excel 8.0; HDR=yes; IMEX=0'"; ;
                OleDbConnection objConn = new OleDbConnection(sUserConnectionString);
                objConn.Open();
                OleDbCommand objCmdSelect = new OleDbCommand("SELECT * FROM [AccountConfig$]", objConn);
                OleDbDataAdapter objAdapter = new OleDbDataAdapter();
                objAdapter.SelectCommand = objCmdSelect;
                objAdapter.Fill(ul);
                for (int i = 0; i < ul.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = ul.Tables[0].Rows[i];
                    try
                    {
                        Console.WriteLine("正在识别第" + (i + 1) + "行");
                        if (dr["乘车人"].ToString() != "" && dr["乘车人身份证号"].ToString() != "" && dr["用户名"].ToString() != "" && dr["邮箱地址"].ToString() != "" && dr["手机号码"].ToString() != "")
                        {
                            UserInfo ui=new UserInfo(dr["乘车人"].ToString(), dr["乘车人身份证号"].ToString(), dr["用户名"].ToString(), dr["邮箱地址"].ToString(), dr["手机号码"].ToString());
                            AccountDict.Add(dr["乘车人"].ToString(), ui);
                            Console.WriteLine("成功识别第" + (i + 1) + "行");
                        }
                        else
                        {
                            Console.WriteLine("该行内容为空或讯息不全，跳过");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("识别第" + (i + 1) + "行失败，错误原因" + e.ToString());
                    }
                }
                Console.WriteLine("读取12306账户信息完成");
                objConn.Close();
            }
            catch (Exception e) {
                Console.WriteLine("读取12306账户信息配置文件失败，错误原因：" + e.ToString());
            }
            #endregion 

            //Load station dictionary
            StationNameTranslation snt = new StationNameTranslation();
            snt.LoadDict();
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
                for (int i = 0; i < workListDataset.Tables[0].Rows.Count; i++) {
                    DataRow dr=workListDataset.Tables[0].Rows[i];
                    try
                    {
                        Console.WriteLine("正在识别第"+(i+1)+"行");
                        if (dr["乘车日期"].ToString() != "")
                        {
                            TrainInfo ti = new TrainInfo(Convert.ToDateTime(dr["乘车日期"]).ToString("yyyy-MM-dd").Substring(0, 10), dr["所乘车次"].ToString(), snt.GetTelegramCode(dr["票面乘车站"].ToString()), snt.GetTelegramCode(dr["票面下车站"].ToString()));
                            try
                            {
                                Worklist.Add(new SurveyBaseInfo(AccountDict[dr["乘车人"].ToString()], ti));
                            }
                            catch (Exception e) 
                            {
                                Console.WriteLine("乘车人信息列表中中找不到名为"+dr["乘车人"].ToString()+"的信息");
                            }      
                            Console.WriteLine("成功识别第" + (i + 1) + "行");
                        }
                        else
                        {
                            Console.WriteLine("该行内容为空，跳过");
                        }
                    }
                    catch (Exception e) {
                        Console.WriteLine("识别第" + (i + 1) + "行失败，错误原因"+e.ToString());
                        UserInfo ui = new UserInfo("###", "###", "###", "###", "###");
                        TrainInfo ti = new TrainInfo("###", e.ToString(), "###", "###");
                        Worklist.Add(new SurveyBaseInfo(ui, ti));
                    }
                    
                }
            }
            catch (Exception e) {
                Console.WriteLine("读取Excel文件失败，错误原因" + e.ToString());
            }

            return Worklist;
        }

        public String Output(List<SurveyBaseInfo> successList, List<SurveyBaseInfo> failedList, List<String> resultList)
        {
            //Output Result to Console
            StationNameTranslation snt = new StationNameTranslation();
            snt.LoadDict();
            DateTime CurrentTime = DateTime.Now;
            String Filename = CurrentTime.ToString("yyyy-MM-dd HHmmss") +".txt";
            FileStream fs = new FileStream(Filename, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding("gb2312"));
            sw.WriteLine("报告打印时间："+CurrentTime.ToString());
            sw.WriteLine("总条目：" + resultList.Count + "  成功" + successList.Count + "条，失败" + failedList.Count + "条");
            sw.WriteLine("");
            sw.WriteLine("1.问卷填写结果(按Excel中顺序每条一行，成功条目显示问卷号，失败条目显示失败原因)");
            sw.WriteLine("");
            foreach (String i in resultList) {
                    sw.WriteLine(i);
            }
            sw.WriteLine("");
            sw.WriteLine("===================");
            sw.WriteLine("2.填写成功的问卷列表(可直接复制到Excel)");
            sw.WriteLine("");
            sw.WriteLine("乘车人\t乘车日期\t所乘车次\t票面乘车站\t票面下车站\t问卷编号");
            foreach (SurveyBaseInfo sbi in successList) {
                sw.WriteLine(sbi.UserAccount.PassengerName+"\t"+sbi.TravelRecord.TravelDate + "\t" + sbi.TravelRecord.TravelTrainNumber + "\t" + snt.GetStationName(sbi.TravelRecord.OnBoardStation) + "\t" + snt.GetStationName(sbi.TravelRecord.OffBoardStation)+"\t"+sbi.SurveyNumber);
            }

            sw.WriteLine("");
            sw.WriteLine("===================");
            sw.WriteLine("3.填写失败的问卷列表(可直接复制到Excel)");
            sw.WriteLine("");
            sw.WriteLine("乘车人\t乘车日期\t所乘车次\t票面乘车站\t票面下车站\t失败原因");
            foreach (SurveyBaseInfo sbi in failedList)
            {
                sw.WriteLine(sbi.UserAccount.PassengerName+"\t"+sbi.TravelRecord.TravelDate + "\t" + sbi.TravelRecord.TravelTrainNumber + "\t" + snt.GetStationName(sbi.TravelRecord.OnBoardStation) + "\t" + snt.GetStationName(sbi.TravelRecord.OffBoardStation) + "\t" + sbi.SurveyNumber);
            }

            sw.Close();
            fs.Close();
            return Filename;
        }
    }
}
