using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SurveyFiller
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
            WebControl wc = WebControl.Instance();
        //    ValidationCodeProcessing vcp = new ValidationCodeProcessing();

        //    foreach (SurveyBaseInfo sbi in WorkList)
        //    {
        //        Console.WriteLine("正在提交第" + i + "张问卷");
        //        if (sbi.TravelRecord.TravelDate == "###")
        //        {
        //            sbi.SurveyNumber = sbi.TravelRecord.TravelTrainNumber;
        //            FailedList.Add(sbi);
        //        }
        //        else
        //        {
        //            String validate = vcp.Validation(sbi.UserName);
        //            String response = "";
        //            if (validate != "ok")
        //            {
        //                response = validate;
        //            }
        //            else
        //            {
        //                response = sc.FillSurvey(sbi, Option);
        //            }

        //            if (response[0] == '0')
        //            {
        //                Console.WriteLine("提交第" + i + "张问卷失败，失败原因：" + response.Substring(2));
        //                ResultList.Add(response.Substring(2));
        //                sbi.SurveyNumber = response.Substring(2);
        //                FailedList.Add(sbi);
        //            }
        //            else
        //            {
        //                Console.WriteLine("提交第" + i + "张问卷成功");
        //                ResultList.Add(response.Substring(2));
        //                sbi.SurveyNumber = response.Substring(2);
        //                SuccessList.Add(sbi);
        //            }
        //        }
        //        i++;
        //    }
        //    Console.WriteLine("正在输出结果到文件...");
        //    String OutputFileName = sc.Output(SuccessList, FailedList, ResultList);
        //    Console.WriteLine("程序运行完成，请到程序目录下查看名为\"" + OutputFileName + "\"的输出文件，按任意键退出程序");
        //    Console.ReadLine();
        }


    }
}
