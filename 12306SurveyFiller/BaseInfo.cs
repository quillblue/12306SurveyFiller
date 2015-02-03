﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyFiller
{
    public class TrainInfo
    {
        public String TravelDate { get; private set; }
        public String TravelTrainNumber { get; private set; }
        public String OnBoardStation { get; private set; }
        public String OffBoardStation { get; private set; }
        public TrainInfo(String travelDate, String travelTrainNumber, String onBoardStation, String offBoardStation)
        {
            this.TravelDate = travelDate;
            this.TravelTrainNumber = travelTrainNumber;
            this.OnBoardStation = onBoardStation;
            this.OffBoardStation = offBoardStation;
        }
    }

    public class SurveyBaseInfo
    {
        public String UserName;
        public String Province;
        public TrainInfo TravelRecord;
        public String SurveyStatus;
        public String SurveyNumber;
        public SurveyBaseInfo(String userName, TrainInfo tr)
        {
            this.UserName = userName;
            this.TravelRecord = tr;
        }
        public String WrapSurveyBaseInfo()
        {
            String info = "{userName:" + this.UserName + ",datepicker:" + this.TravelRecord.TravelDate + ",board_train_no:" + this.TravelRecord.TravelTrainNumber + ",board_station:" + this.TravelRecord.OnBoardStation + ",down_station:" + this.TravelRecord.OffBoardStation + "}";
            return info;
        }
    }
}
