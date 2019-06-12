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

namespace TMS.ConsoleTest
{
    class Program
    {
        static private WebApiServices services = new WebApiServices();

        static void Main(string[] args)
        {


            Console.WriteLine("login");
            var login = Console.ReadLine();

            Console.WriteLine("password");
            var password = Console.ReadLine();

            var res = services.Authorization(login, password);
            Console.WriteLine(res);

            var list = services.GetAll<Report>();
            foreach(var item in list)
            {
                Console.WriteLine("Report: " + item.Id);
                foreach(var property in item.GetType().GetProperties())
                {
                    Console.WriteLine(property.GetValue(item));
                }
            }

            Console.Read();
        }   
    }
}
