using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Reflection;
using System.Threading;
using System.Windows;

namespace mainapp
{

    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs e)
        {
            string _resName = MethodBase.GetCurrentMethod().DeclaringType.Namespace + ".libs." + new AssemblyName(e.Name).Name + ".dll";
            //using (var _stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(_resName))
            //{
            //    if (_stream == null)
            //    {
            //        return null;
            //    }
            //    byte[] _data = new byte[_stream.Length];
            //    _stream.Read(_data, 0, _data.Length);
            //    return Assembly.Load(_data);
            //}
            using (System.IO.Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(_resName))
            {
                if (stream == null)
                    return null;

                byte[] assemblyRawBytes = new byte[stream.Length];
                stream.Read(assemblyRawBytes, 0, assemblyRawBytes.Length);
                return Assembly.Load(assemblyRawBytes);
            }
        }

    }

    public class EntryPoint
    {
        [STAThread]
        public static void Main(string[] args)
        {
            SingleInstanceManager manager = new SingleInstanceManager();
            manager.Run(args);
        }
    }


    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            //AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve001;
            InitializeComponent();
        }

        public void Activate()
        {
            this.MainWindow.Show();
            this.MainWindow.Activate();
        }
    }
    public class SingleInstanceManager :
        Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase
    {
        private App wpfapp; // 这才是真正的WPF Application

        public SingleInstanceManager()
        {
            this.IsSingleInstance = true;
        }

        // 第一次打开调这个方法
        protected override bool OnStartup(
            Microsoft.VisualBasic.ApplicationServices.StartupEventArgs e)
        {
            wpfapp = new App();
            wpfapp.Run();

            return false;
        }

        /// <summary>
        /// 当有其他应用程序实例化时，则触发此事件，弹出已存在的实例窗口
        /// </summary>
        /// <param name="eventArgs"></param>
        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
        {
            // Subsequent launches
            base.OnStartupNextInstance(eventArgs);
            wpfapp.Activate();
        }
    }

}
