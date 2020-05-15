using System;

namespace Vejrstation.Entities
{
    public class WeatherObservation
    {
        public DateTime Date { get; set; }
        public Location Location { get; set; }
        public double TemperatureCelsius { get; set; }
        public int Humidity_Percentage { get; set; }
        public double Pressure_Millibar { get; set; }
    }
}