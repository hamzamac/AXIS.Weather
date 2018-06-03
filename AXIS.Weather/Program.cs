using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AXIS.Weather
{
    class Program
    {
        static void Main(string[] args)
        {

            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            Report report = new Report();

            //Dispaly AverageTemperatureInLastHour in Sweden
            Console.WriteLine(report.AverageTemperatureInLastHour() + "\n");

            //Dispaly TotalRainfallForTheLastMonth in Lund
            Console.WriteLine(report.TotalRainfallForTheLastMonth() + "\n");

            //listen for the keypressed and cancel the TockenSource if any key pressed
            Thread KeyListenerThread = new Thread(() => {
                if (Console.ReadKey(true).KeyChar.ToString().ToUpperInvariant() != "")
                {
                    cts.Cancel();
                    cts.Dispose();
                }
            });

            KeyListenerThread.Start();

            //Dispaly all Station's Temperature
            report.StationsTemperatureAsync(token).GetAwaiter();

            Console.ReadKey(true);
        }

    }
}
