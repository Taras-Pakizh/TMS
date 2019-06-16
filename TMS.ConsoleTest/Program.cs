using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using TMS.Services;
using TMS.Data;
using System.Data.Entity;
using TMS.ViewModels;

namespace TMS.ConsoleTest
{
    class Program
    {
        static private WebApiServices services = new WebApiServices();

        

        static void Main(string[] args)
        {
            var item = (ReportView) Activator.CreateInstance("TMS.ViewModels", "TMS.ViewModels.ReportView").Unwrap();

            //item.Unwrap();

            var h = Activator.CreateInstance(typeof(ReportView));
            Console.Read();
        }   
    }
}
