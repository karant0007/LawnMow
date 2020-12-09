using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lawn_Mow_App.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Weather
    {
        public float id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Current
    {
        public int dt { get; set; }
        public float sunrise { get; set; }
        public float sunset { get; set; }
        public float temp { get; set; }
        public double feels_like { get; set; }
        public float pressure { get; set; }
        public float humidity { get; set; }
        public double dew_point { get; set; }
        public float uvi { get; set; }
        public float clouds { get; set; }
        public float visibility { get; set; }
        public double wind_speed { get; set; }
        public float wind_deg { get; set; }
        public List<Weather> weather { get; set; }
    }

    public class Minutely
    {
        public int dt { get; set; }
        public float precipitation { get; set; }
    }

    public class Hourly
    {
        public int dt { get; set; }
        public double temp { get; set; }
        public double feels_like { get; set; }
        public float pressure { get; set; }
        public float humidity { get; set; }
        public double dew_point { get; set; }
        public double uvi { get; set; }
        public float clouds { get; set; }
        public int visibility { get; set; }
        public double wind_speed { get; set; }
        public float wind_deg { get; set; }
        public List<Weather> weather { get; set; }
        public double pop { get; set; }
    }

    public class Temp
    {
        public double day { get; set; }
        public double min { get; set; }
        public double max { get; set; }
        public double night { get; set; }
        public double eve { get; set; }
        public double morn { get; set; }
    }

    public class FeelsLike
    {
        public double day { get; set; }
        public double night { get; set; }
        public double eve { get; set; }
        public double morn { get; set; }
    }

    public class Daily
    {
        public int dt { get; set; }
        public float sunrise { get; set; }
        public float sunset { get; set; }
        public Temp temp { get; set; }
        public FeelsLike feels_like { get; set; }
        public float pressure { get; set; }
        public float humidity { get; set; }
        public double dew_point { get; set; }
        public double wind_speed { get; set; }
        public float wind_deg { get; set; }
        public List<Weather> weather { get; set; }
        public int clouds { get; set; }
        public float pop { get; set; }
        public double uvi { get; set; }
        public double? rain { get; set; }
    }

    public class WeatherForecast
    {
        public double lat { get; set; }
        public double lon { get; set; }
        public string timezone { get; set; }
        public float timezone_offset { get; set; }
        public Current current { get; set; }
        public List<Minutely> minutely { get; set; }
        public List<Hourly> hourly { get; set; }
        public List<Daily> daily { get; set; }
    }


}