using System;

namespace Vejrstation
{
    public class Location
    {
        string Name;
        double Latitude;
        double Longitude;

        public Location(string name, double latitude, double longitude)
        {
            this.Name = name;
            this.Latitude = latitude;
            this.Longitude = longitude;
        }
    }

    public class WeatherObservation
    {
        public DateTime Date { get; set; }
        public Location Location { get; set; }
        public double TemperatureCelsius { get; set; }
        public int Humidity_Percentage { get; set; }
        public double Pressure_Millibar { get; set; }
    }
}