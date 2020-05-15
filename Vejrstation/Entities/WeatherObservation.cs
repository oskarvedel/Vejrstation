using System;

namespace Vejrstation
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        
        public string Location { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        
        public double TemperatureC { get; set; }
        
        public int Humidity { get; set; }
        public double Pressure { get; set; }
    }
}