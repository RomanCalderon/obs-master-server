using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterServer
{
    public class Program
    {
#pragma warning disable CS1591
        public static void Main ( string [] args )
        {
            CreateHostBuilder ( args ).Build ().Run ();
        }

        public static IHostBuilder CreateHostBuilder ( string [] args ) =>
            Host.CreateDefaultBuilder ( args )
                .ConfigureWebHostDefaults ( webBuilder =>
                  {
                      webBuilder.UseStartup<Startup> ();
                      webBuilder.UseUrls ( "http://0.0.0.0:44334", "https://0.0.0.0:44335" );
                  } );
#pragma warning restore CS1591
    }
}
