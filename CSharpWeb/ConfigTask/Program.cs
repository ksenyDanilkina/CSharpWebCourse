using System;
using System.Configuration;
using TestTask;

namespace ConfigTask
{
    public class Program
    {
        static void Main(string[] args)
        {
            var siteUrl = ConfigurationManager.AppSettings["SiteUrl"];

            Console.WriteLine($"Адрес сайта: {siteUrl}");
        }
    }
}
