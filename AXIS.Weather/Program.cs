using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AXIS.Weather
{
    class Program
    {
        static void Main(string[] args)
        {
            Report report = new Report();

            Console.Write(report.Task2());

            Console.Read();
        }
    }
}
