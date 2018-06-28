using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace KestrelPlatform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }
        //Open source ve cross platform olması. Basit bir yapıya sahiptir.
        //Light weight ve aspnet core application var sayılan webserver
        //Kestrel server bazı işlemleri tek başına halledemez ve bunun için ISS ve apache den yardımalarak tamamlamasıdır.
        //SSL desteği var.
        //windows linux ve mac de çalışır.



        public static IWebHost BuildWebHost(string[] args) =>
          new WebHostBuilder()
            .UseKestrel() // dll tanımlaması yapılıyor.
            .UseContentRoot(Directory.GetCurrentDirectory())   // server anadizinin üzerinden aktif edilir.
            .ConfigureAppConfiguration(config => config.AddJsonFile("appSettings.json", true)) // uygulama içindeki appsetting dosyası tanımlanır
           .UseIISIntegration() // proxy olarak çalışması sağlanıyor.
            .UseStartup<Startup>()
            .Build();

    }
}
