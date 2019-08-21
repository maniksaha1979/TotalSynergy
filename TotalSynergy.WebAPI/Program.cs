using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace TotalSynergy.WebAPI
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            var config = new HttpSelfHostConfiguration("http://localhost:54967/");
            config.Routes.MapHttpRoute(
              name: "DefaultApi",
              routeTemplate: "api/{controller}/{id}",
              defaults: new { id = RouteParameter.Optional }
            );
            var server = new HttpSelfHostServer(config);
            var task = server.OpenAsync();
            task.Wait();

            Console.WriteLine("Web API Server has started at http://localhost:54967/");
            Console.ReadLine();
        }
    }
}