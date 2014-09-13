12306SurvelFiller
=================
 
 This is a C# console application for filling investigation forms with lottery quickly on 12306.cn.
 
 Content Code File:
 BaseInfo.cs: Define the UserAccount and TravelRecord class
 SurveyControl.cs:Functional class for loading workload and output
 WebControl.cs: Post HTTP Request to 12306.cn
 StationNameList.cs: Functional class for converting the name of the station to telegram code used by 12306.cn
 Program.cs: Main Program
 
 After Compiling, you need to:
 #Copy StationList.txt file to the folder of application. You can maintain it mannually when needed.(Unproper maintainence will cause unknown errors, please be sure you know about telegram code of stations used in China Railway System) When modifying it, input with station names and their telegram code(with a tab between them). 
 #Prepare a Excel 97-2003 file with table Sheet1 and AccountConfig, which have at least four coloums names “乘车日期”“所乘车次”“票面乘车站”“票面下车站” in Sheet1 and at least five coloums names “乘车人”“乘车人身份证号”“用户名”“邮箱地址”“手机号码” in AccountConfig.
 

 When running, you will need to:
 #Input the filename of Excel(e.g. 1.xls),1.xls will be the default option.
 #Input the filename of Account Config File(e.g. myAccount.txt), AccountConfig.txt will be the default option
 #Choose to give best comment or ordinary comment, the former is the default option.
 #Find the result file according the instruction of console.