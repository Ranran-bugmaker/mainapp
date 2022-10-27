using System;
using mainapp;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mainapp.Base_Class
{
    public class sidebarclass
    {
        public string name { get;  set; }
        public int _id { get; set; }
    }

    public class Lisbar
    {
        public List<sidebarclass> GetList()
        {
            List<sidebarclass> list=new List<sidebarclass>();
            list.Add(new sidebarclass()
            {
                name = @"定时关机",
                _id = 10000
            });
            list.Add(new sidebarclass()
            {
                name = @"定时关机ces",
                _id = 10002
            });
            //new Sidebar.listclock();
            return list;
        }


    }
}
