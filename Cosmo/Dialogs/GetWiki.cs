using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cosmo.Dialogs
{
    public class GetWiki
    {
        public static async Task<Strings> GetData(string ZipCode)
        {
            //Uri ServiceURL = new Uri(string.Format("http://api.openweathermap.org/data/2.5/weather?zip={0}&APPID={1}&units=imperial", ZipCode, APIKEY));
            //Uri ServiceURL = new Uri(string.Format("https://api.nasa.gov/planetary/apod?api_key=rXDVLSbsZjhcNkrs0dl52tPbrpiI2g9xGSW7vHpo"));
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(ZipCode);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            Strings conditions = JsonConvert.DeserializeObject<Strings>(result);
            return conditions;
        }

    }
}