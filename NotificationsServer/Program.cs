using System;

namespace NotificationsServer
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = @"http://localhost:8080/";
            using (Microsoft.Owin.Hosting.WebApp.Start<Startup>(url))
            {
                Console.WriteLine(string.Format("Server running at {0}", url));
                Console.ReadLine();
            }
        }
    }
}
