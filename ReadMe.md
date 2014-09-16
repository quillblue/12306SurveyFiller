##12306SurvelFiller
 
This is a C# console application for filling investigation forms with lottery quickly on 12306.cn.
 
Content Code File:

	BaseInfo.cs: Define the UserAccount and TravelRecord class
	SurveyControl.cs:Functional class for loading workload, wraping filling forms and write result to output file.
	ValidationCodeProcess:Functional class for dealing with mobile verification.
	WebControl.cs: Singleton class for sending HTTP Request to 12306.cn
	StationNameList.cs: Functional class for converting the name of the station to telegram code used by 12306.cn
	Program.cs: Main Program


 After Compiling, you need to:

- Copy `StationList.txt` file from `Example Config File` to the folder of application. You can maintain it mannually when needed.(Since unproper maintainence will cause unknown errors, please be sure you know about telegram code of stations used in China Railway System) When modifying it, input with station names and their telegram code(with a tab between them). 
- Prepare a Excel 97-2003 file with table Sheet1, which have at least five coloums names “用户名”“乘车日期”“所乘车次”“票面乘车站”“票面下车站” in Sheet1.
> In here, “用户名” means the username of 12306 account ownerd by the people who took this train.
 

 When running, you will need to:

1. Input the filename of Excel(e.g. 1.xls),1.xls will be the default option.
2. Choose to give best comment or ordinary comment, the former is the default option.
3. During survey form submiting, the application may be paused waiting for you to enter the validation code you receieved on your cellphone. Please check carefully that the validation code and sequence number are matched.
4. Find the result file according the instruction of console.