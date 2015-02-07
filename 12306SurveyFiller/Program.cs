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

        //    String OutputFileName = sc.Output(SuccessList, FailedList, ResultList);
        }
    }
}
