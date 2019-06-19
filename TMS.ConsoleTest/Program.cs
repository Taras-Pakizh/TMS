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
            services.Authorization("Pakizh_engineer", "Taras20.");

            var reports = services.GetAllAsync<ReportView>().Result;

            var tasks = services.GetAllAsync<TaskView>().Result;

            Console.WriteLine(reports.Count().ToString() + " " + tasks.Count().ToString());

            Console.Read();
        }   
    }
}
