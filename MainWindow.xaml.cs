using mainapp.Base_Class;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

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
            Random ran = new Random();
            sidebarlist = new List<sidebarclass>();
            for (int i = 0; i < 5; i++)
            {
                sidebarlist.Add(new sidebarclass()
                {
                    name = i.ToString(),
                    _id = ran.Next(10000,20000)
                }) ;
            }
            //Sidebarclasses = new sidebarclass();
            //Sidebarclasses.name = "164641";
            BarMain.ItemsSource = sidebarlist;
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void mainD_Click(object sender, RoutedEventArgs e)
        {
            Sidebar.IsOpen = true;
        }

        private void BarMain_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

            testtext.Text = ((sidebarclass)BarMain.SelectedItem).name + '_' + ((sidebarclass)BarMain.SelectedItem)._id + "____" + TIMES.DisplayTime.TimeOfDay;

        }
    }
}
