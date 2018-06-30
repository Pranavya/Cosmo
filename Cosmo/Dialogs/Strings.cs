using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Web;

namespace Cosmo.Dialogs
{
    public class Strings
    {
        [JsonProperty("weather")]
        public IList<Weather> Weather { get; set; }
        [JsonProperty("main")]
        public Main Main { get; set; }
        [JsonProperty("name")]
        public string CityName { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("explanation")]
        public string explanation { get; set; }
    }
    public class Weather
    {
        [JsonProperty("main")]
        public string Main { get; set; }
    }
    public class Main
    {
        [JsonProperty("temp")]
        public decimal Temperature { get; set; }
    }
}