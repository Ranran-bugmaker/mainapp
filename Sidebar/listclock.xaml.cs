using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace mainapp.Sidebar
{
    /// <summary>
    /// listclock.xaml 的交互逻辑
    /// </summary>
    public partial class listclock : UserControl
    {
        public listclock()
        {
            InitializeComponent();
        }

        private void TIMES_MouseLeave(object sender, MouseEventArgs e)
        {
            //longtimes.Text = TIMES.DisplayTime.TimeOfDay.ToString()+"--/--"+ TIMES.DisplayTime.TimeOfDay.TotalSeconds.ToString();
        }

        private void cmd(int time,bool stop=false,bool cq=false)
        {
            //if (time ==0)
            //{
            //    time = 100000;
            //}
            bool stt;
            //创建一个进程
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;//是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = true;//不显示程序窗口
            p.Start();//启动程序
            string inputcmd;
            if (!stop)
            {
                inputcmd = "shutdown /s /t " + time.ToString();
                stt = false;
            }
            else
            {
                inputcmd = "shutdown /a";
                stt = true;
            }
            if (cq == true)
            {
                inputcmd = "shutdown /r /t 10 /f";
            }
            p.StandardInput.WriteLine(inputcmd + " &exit");
            string output = p.StandardOutput.ReadToEnd();

            p.StandardInput.AutoFlush = true;
            string err = p.StandardError.ReadLine();
            //this.outp.Text = output + err;
            if (!string.IsNullOrEmpty(err))
            {
                HandyControl.Controls.Growl.Error(err);
            }
            else
            {
                if (cq)
                {
                    HandyControl.Controls.Growl.Success("将于10秒后重启");
                }
                else if (!string.IsNullOrEmpty(output) && !stt)
                {
                    string sussces= "将于";
                    if (TIMES.DisplayTime.Hour==0)
                    {
                        sussces += TIMES.DisplayTime.Minute.ToString() + "分后关机";
                    }
                    else
                    {
                        sussces += TIMES.DisplayTime.Hour.ToString() + "时" +TIMES.DisplayTime.Minute.ToString() + "分后关机";
                    }
                    HandyControl.Controls.Growl.Success(sussces);
                    
                }
                else
                {
                    HandyControl.Controls.Growl.Success("已取消计划关机任务");
                }
            }
            p.WaitForExit();
            p.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cmd((int)TIMES.DisplayTime.TimeOfDay.TotalSeconds);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            cmd((int)TIMES.DisplayTime.TimeOfDay.TotalSeconds, true);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            cmd((int)TIMES.DisplayTime.TimeOfDay.TotalSeconds,cq:true);
        }
    }
}
