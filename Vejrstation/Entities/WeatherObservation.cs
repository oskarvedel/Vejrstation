using System;

namespace Vejrstation
{
    public class WeatherObservation
    {
        public DateTime Date { get; set; }
        
        public string Location { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        
        public double Temperature_Celcius { get; set; }
        
        public int Humidity_Percentage { get; set; }
        public double Pressure_Millibar { get; set; }
    }
}