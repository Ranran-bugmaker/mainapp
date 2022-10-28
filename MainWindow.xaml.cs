using mainapp.Base_Class;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace mainapp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<sidebarclass> sidebarlist;
        public MainWindow()
        {
            InitializeComponent();

            sidebar_Init();
            if (maingrid.Children.Count<0)
            {
                maingrid.Children.Add(new Sidebar.HomePage());
            }
            //maingrid.Children.Add(new Sidebar.HomePage());
        }

        public void sidebar_Init()
        {
            Lisbar a = new Lisbar();
            sidebarlist = a.GetList();
            //listbar listbar = new listbar();
            //sidebarlist = listbar.GetList;
            //Random ran = new Random();
            //sidebarlist = new List<sidebarclass>();

            //sidebarlist.Add(new sidebarclass()
            //{
            //    name = @"定时关机",
            //    _id = 10000
            //});
            //Sidebarclasses = new sidebarclass();
            //Sidebarclasses.name = "164641";
            BarMain.ItemsSource = sidebarlist;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void mainD_Click(object sender, RoutedEventArgs e)
        {
            Sidebars.IsOpen = true;
        }

        private bool mainId =false;
        private void BarMain_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (((sidebarclass)BarMain.SelectedItem) == null)
            {
                return;
            }
            maingrid.Children.Clear();
            if (((sidebarclass)BarMain.SelectedItem)._id == 10000)
            {
                maingrid.Children.Add(new Sidebar.listclock());
                mainId = true;
            }
            if (!mainId)
            {
                maingrid.Children.Add(new Sidebar.None());
            }
            //testtext.Text = ((sidebarclass)BarMain.SelectedItem).name + '_' + ((sidebarclass)BarMain.SelectedItem)._id + "____" + TIMES.DisplayTime.TimeOfDay;

        }



        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            grid.Height = maingrid.Height;
            Application.Current.MainWindow.WindowState = WindowState.Normal;
            Application.Current.MainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Application.Current.MainWindow.Topmost = false;
            mainWindos.Top = (SystemParameters.FullPrimaryScreenHeight - mainWindos.Height) / 2;
            mainWindos.Left = (SystemParameters.FullPrimaryScreenWidth - mainWindos.Width) / 2;
            Application.Current.MainWindow.SizeToContent = SizeToContent.WidthAndHeight;

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.SizeToContent = SizeToContent.Manual;
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
            Application.Current.MainWindow.Topmost = true;
        }

        private bool AltKeyDown = false;
        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            Key key = (e.Key == Key.System ? e.SystemKey : e.Key);
            if (key == Key.LeftAlt || key == Key.RightAlt || key == Key.F4)
            {
                AltKeyDown = true;
            }
            if (key == Key.F4 && AltKeyDown)
            {
                e.Handled = true;
            }
        }

        public static string pos = "";
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            pos = e.GetPosition(null).ToString();
            //movbe.Text = e.GetPosition(null).ToString();
            if (mainWindos.WindowState == WindowState.Maximized)
            {
                if (e.GetPosition(grid).X < 50)
                {
                    Sidebars.IsOpen = true;
                }
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                //e.d
                DragMove();
            }
        }

        private void BarMain_MouseLeave(object sender, MouseEventArgs e)
        {
            //Thread thread = new Thread(new ParameterizedThreadStart(openclose));
            //thread.Start(500);
            //Sidebar.IsOpen = false;
        }

        private void openclose(object obj)
        {
            Thread.Sleep(Convert.ToInt32(obj));

            Sidebars.Dispatcher.Invoke(new Action(() =>{
                Sidebars.IsOpen = false;
            }));
            //bg.Dispatcher.Invoke(new Action(() => { bg.Visibility = Visibility.Hidden; }));
        }

        private void maingrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (maingrid.Height ==double.NaN)
            {
                Application.Current.MainWindow.Height = maingrid.Height;
            }
            
        }

    }
}
