using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestServerSelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //Quick File Server
            //var url = "http://localhost:8080";
            //WebApp.Start(url, builder => builder.UseFileServer(enableDirectoryBrowsing: true));
            //Console.WriteLine("Listening at " + url);
            //Console.ReadLine();

            //return;


            string baseAddress = "http://localhost:9000/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                System.Console.WriteLine("Server running on port: " + baseAddress);
                // Create HttpCient and make a request to api/values 
                HttpClient client = new HttpClient();

                var response = client.GetAsync(baseAddress + "api/values").Result;

                Console.WriteLine(response);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);

                Console.ReadLine();
            }            
        }
    }
}
