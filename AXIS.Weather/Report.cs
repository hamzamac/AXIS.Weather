using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AXIS.Weather
{
    class Report
    {
        private ApiClient _api = new ApiClient();

        private string Query(string parameter, string station, string period)
        {
            return $"api/version/1.0/parameter/{parameter}/station/{station}/period/{period}/data.json";
        }

        public string Task1()
        {
            // Rreceve data as JObject
            var o = _api.GetDataAsync("").GetAwaiter().GetResult();

            //perform necessary computation


            //return string result
            return "OK";
        }

        public string Task2()
        {
            string totalTemperature;
            string fromDate;
            string toDate;
            string city;
            string dateFormater = "yyyy-MM-dd";

            // Rreceve data as JObject
            var data = _api.GetDataAsync(Query("23", "53430", "latest-months"))
                .GetAwaiter()
                .GetResult();

            //Calculate the total rainfall

            //get the string values latest month temperatures
            List<string> temp = data["value"].Select(v => ((string)v["value"])).ToList();

            //convert the tenperatures to double and get their sum
            totalTemperature = temp.Select(t => double.Parse(t, CultureInfo.InvariantCulture))
                                   .Sum().ToString();

            // get the time range
            long miliseconds = (long)data["period"]["from"];
            fromDate = DateTimeOffset.FromUnixTimeMilliseconds(miliseconds).Date.ToString(dateFormater);
            
            // get the name oof the city
            miliseconds = (long)data["period"]["to"];
            toDate = DateTimeOffset.FromUnixTimeMilliseconds(miliseconds).Date.ToString(dateFormater);

            // get city name
            city = (string)data["station"]["name"];

            //construct the display string and return
            return $"Between {fromDate} and {toDate} the total rainfall in {city} was {totalTemperature} millimeters"; 
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
