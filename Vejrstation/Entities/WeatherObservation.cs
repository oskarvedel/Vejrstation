using System;

namespace Vejrstation.Entities
{
    public class WeatherObservation
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double TemperatureCelsius { get; set; }
        public int Humidity_Percentage { get; set; }
        public double Pressure_Millibar { get; set; }
    }
}