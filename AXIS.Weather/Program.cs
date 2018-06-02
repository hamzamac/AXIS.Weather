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
        
        static async Task<string> GetData()
        {


            return await GetDataAsync("api/version/1.0/parameter/1/station/159880/period/latest-months/data.json");
        }

        static void Main(string[] args)
        {
            Console.Write(GetData().GetAwaiter().GetResult());
            Console.Read();
        }
    }
}
