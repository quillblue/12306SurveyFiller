using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyFiller
{
    public class TrainInfo
    {
        public String TravelDate { get; private set;  }
        public String TravelTrainNumber { get; private set; }
        public String OnBoardStation { get; private set; }
        public String OnBoardStationDisplay { get; private set; }
        public String OffBoardStationDisplay { get; private set; }
        public String OffBoardStation { get; private set; }
        public TrainInfo(String travelDate, String travelTrainNumber, String onBoardStation, String offBoardStation)
        {
            this.TravelDate = travelDate;
            this.TravelTrainNumber = travelTrainNumber;
            this.OnBoardStation = onBoardStation;
            this.OnBoardStationDisplay = onBoardStation;
            this.OffBoardStation = offBoardStation;
            this.OffBoardStationDisplay = offBoardStation;
        }

        public void TranslateStation(String on, String off){
            this.OnBoardStation = on;
            this.OffBoardStation = off;
        }
    }

    public class SurveyBaseInfo
    {
        public String UserName;
        public String Province;
        public TrainInfo TravelRecord;
        public String SurveyStatus;
        public String SurveyNumber;

        public SurveyBaseInfo(String userName, TrainInfo tr, String failedReason="")
        {
            this.UserName = userName;
            this.TravelRecord = tr;
            this.SurveyStatus = failedReason==""?"等待":"失败";
            this.SurveyNumber = failedReason;
        }

        public String WrapSurveyBaseInfo(String province)
        {
            this.Province = province;
            String info = "{userName:" + this.UserName + ",datepicker:" + this.TravelRecord.TravelDate + ",board_train_no:" + this.TravelRecord.TravelTrainNumber + ",board_station:" + this.TravelRecord.OnBoardStation + ",down_station:" + this.TravelRecord.OffBoardStation + ",province:"+this.Province+"}";
            return info;
        }

        public void UpdateStatus(String status, String surveyNumber)
        {
            this.SurveyStatus = status;
            this.SurveyNumber = surveyNumber;
        }
    }
}
