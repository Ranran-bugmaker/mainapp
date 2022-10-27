using Base_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mainappDLL
{
    public class listbar
    {
        private List<sidebarclass> sidebarlist;
        public List<sidebarclass> GetList
        {
            get {
                sidebarlist = new List<sidebarclass>();

                sidebarlist.Add(new sidebarclass()
                {
                    name = @"定时关机",
                    _id = 10000
                });
                return sidebarlist;
            }
        }
    }
}
