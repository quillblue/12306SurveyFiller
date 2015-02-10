##12306SurvelFiller V3.0
 
This is a C# WinForm application for filling investigation forms with lottery quickly on 12306.cn.
 
 After Compiling(or get the building result from `BuildResult` folder, you need to:

- Copy `StationList.txt` file from `Example Config File` to the folder of application. You can maintain it mannually when needed.(Since unproper maintainence will cause unknown errors, please be sure you know about telegram code of stations used in China Railway System) When modifying it, input with station names and their telegram code(with a tab between them). 
- Prepare a Excel 97-2003 file with table Sheet1, which have at least five coloums names “用户名”“乘车日期”“所乘车次”“票面乘车站”“票面下车站” in Sheet1.
> In here, “用户名” means the username of 12306 account ownerd by the people who took this train.
 

 When running, you will need to:

1. Find your Excel file.
2. Choose to give best comment or ordinary comment, the former is the default option.
3. During survey form submiting, the application may be paused waiting for you to enter the validation code you receieved on your cellphone. Please check carefully that the validation code and sequence number are matched. The submiting result could be found at the buttom table of the form
4. Click "Start|Retry" button to run again if some work is marked as "Could retry", or just click "Export result" to save the result report to .txt file.