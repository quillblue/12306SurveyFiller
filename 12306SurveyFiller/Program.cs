﻿using System;
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
        }
    }
}
