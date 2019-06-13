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

        static void Man(string[] args)
        {

            using (var context = new MyContext())
            {
                var model1 = (Report)context.Reports.Find(21);
                var model2 = context.Reports.Find(22);

                var model = new Report()
                {
                    Id = 21,
                    activity = ActivityType.Bug_fixing,
                    description = "Fuckkkkkkk already",
                    effort = 100,
                    status = ReportStatus.Open,
                    start = DateTime.Now,
                    end = DateTime.Now,
                    //engineerId = 162,
                    //taskId = 6
                };

                foreach (var property in typeof(Report).GetProperties())
                {
                    property.SetValue(model1, property.GetValue(model));
                }
            }

            Console.WriteLine("Finish");

            Console.Read();
        }

        static void Main(string[] args)
        {


            //Console.WriteLine("login");
            //var login = Console.ReadLine();

            //Console.WriteLine("password");
            //var password = Console.ReadLine();

            Console.WriteLine("Start?");
            Console.ReadLine();

            var res = services.Authorization("Pakizh_engineer", "Taras20.");
            Console.WriteLine(res);

            var model = new ReportView()
            {
                Id = 24,
                activity = ActivityType.Bug_fixing,
                description = "Holy Fuck bhbkbkbkbjn",
                effort = 100,
                status = ReportStatus.Open,
                start = DateTime.Now,
                end = DateTime.Now,
                engineerId = 161,
                taskId = 10
            };

            var result = services.Update(model);
            
            Console.WriteLine(result);

            Console.Read();
        }   
    }
}
