using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SurveyFiller
{
    public class StationNameTranslation
    {
        Dictionary<String,String> StationDict=new Dictionary<String,String>();
        Dictionary<String, String> AntiStationDict = new Dictionary<String, String>();
        public void LoadDict() {
            FileStream fs = new FileStream("StationList.txt", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("gb2312"));
            string line, StationName, TelegramCode;
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine().Trim();
                if (line.Contains(" "))
                {
                    StationName = line.Substring(0, line.IndexOf(' '));
                    TelegramCode = line.Substring(line.IndexOf(' ') + 1);
                }
                else
                {
                    StationName = line.Substring(0, line.IndexOf('\t'));
                    TelegramCode = line.Substring(line.IndexOf('\t') + 1);
                }
                StationDict.Add(StationName, TelegramCode);
                AntiStationDict.Add(TelegramCode, StationName);
            }
            sr.Close();
            fs.Close();
        }
        public String GetTelegramCode(String stationName) {
            try
            {
                return StationDict[stationName];
            }
            catch(Exception e) {
                return null;
            }
        }
        public String GetStationName(String telegramCode) {
            try
            {
                return AntiStationDict[telegramCode];
            }
            catch (Exception)
            {
                return telegramCode;
            }
        }
    }
}
