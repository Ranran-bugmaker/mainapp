using System;
using System.Reflection;
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
            //AppDomain.CurrentDomain.AssemblyResolve += OnResolveAssembly;
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
        private static Assembly OnResolveAssembly(object sender, ResolveEventArgs args)
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            var executingAssemblyName = executingAssembly.GetName();
            var resName = executingAssemblyName.Name + ".resources";

            AssemblyName assemblyName = new AssemblyName(args.Name); string path = "";
            if (resName == assemblyName.Name)
            {
                path = executingAssemblyName.Name + ".libs.";
            }
            else
            {
                path = assemblyName.Name + ".dll";
                if (assemblyName.CultureInfo.Equals(System.Globalization.CultureInfo.InvariantCulture) == false)
                {
                    path = String.Format(@"{0}\{1}", assemblyName.CultureInfo, path);
                }
            }

            using (System.IO.Stream stream = executingAssembly.GetManifestResourceStream(path))
            {
                if (stream == null)
                    return null;

                byte[] assemblyRawBytes = new byte[stream.Length];
                stream.Read(assemblyRawBytes, 0, assemblyRawBytes.Length);
                return Assembly.Load(assemblyRawBytes);
            }
        }
    }
}
