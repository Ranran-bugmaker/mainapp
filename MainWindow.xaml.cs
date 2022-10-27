using Base_Class;
using mainappDLL;
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
        }

        public void sidebar_Init()
        {
            listbar listbar = new listbar();
            sidebarlist = listbar.GetList;
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
            Sidebar.IsOpen = true;
        }

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
            }
            //testtext.Text = ((sidebarclass)BarMain.SelectedItem).name + '_' + ((sidebarclass)BarMain.SelectedItem)._id + "____" + TIMES.DisplayTime.TimeOfDay;

        }



        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Normal;
            Application.Current.MainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Application.Current.MainWindow.Topmost = false;
            mainWindos.Top = (SystemParameters.FullPrimaryScreenHeight - mainWindos.Height) / 2;
            mainWindos.Left = (SystemParameters.FullPrimaryScreenWidth - mainWindos.Width) / 2;

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
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

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                //e.d
                DragMove();
            }
        }
    }
}
