using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AXIS.Weather
{
    class Report
    {
        private ApiClient _api = new ApiClient();

        public string Task1()
        {
            // Rreceve data as JObject
            var o = _api.GetDataAsync("api/version/1.0/parameter/1/station/159880/period/latest-months/data.json").GetAwaiter().GetResult();

            //perform necessary computation


            //return string result
            return "OK";
        }

        public string Task2()
        {
            // Rreceve data as JObject
            var o = _api.GetDataAsync("").GetAwaiter().GetResult();

            //perform necessary computation


            //return string result
            return "OK";
            throw new NotImplementedException();
        }

        public string Task3()
        {
            // Rreceve data as JObject
            var o = _api.GetDataAsync("api/version/1.0/parameter/1/station/159880/period/latest-months/data.json").GetAwaiter().GetResult();

            //perform necessary computation


            //return string result
            return "OK";
            throw new NotImplementedException();
        }
    }
}
