using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vejrstation.Entities;

namespace Vejrstation.EntityConfigurations
{
    public class WeatherObservationConfigurations : IEntityTypeConfiguration<WeatherObservation>
    {
        public void Configure(EntityTypeBuilder<WeatherObservation> builder)
        {
            builder.HasData(new WeatherObservation
            {
                Id = 1,
                Date = new DateTime(2020,5,20),
                Name = "Kolding",
                Latitude = 101010101,
                Longitude = 2222222,
                TemperatureCelsius = 1,
                Humidity_Percentage = 2,
                Pressure_Millibar = 3
            },
                new WeatherObservation
                {
                    Id=1002,
                    Date = new DateTime(2020, 05, 03, 9, 0, 0),
                    Name = "Bunden af bubbers badekar",
                    Latitude = 23.45224,
                    Longitude = 19.353,
                    TemperatureCelsius = 33.1,
                    Humidity_Percentage = 10,
                    Pressure_Millibar = 9.2
                },
                new WeatherObservation
                {
                    Id=1003,
                    Date = new DateTime(2020, 02, 03, 1, 50, 0),
                    Name = "Himmelbjerget",
                    Latitude = 12.46733,
                    Longitude = 2.2352,
                    TemperatureCelsius = 33.1,
                    Humidity_Percentage = 10,
                    Pressure_Millibar = 9.2
                },
                new WeatherObservation
                {
                    Id=1004,
                    Date = new DateTime(2020, 11, 15, 9, 0, 0),
                    Name = "Hjemme paa gaarden",
                    Latitude = 56.158150,
                    Longitude = 10.212030,
                    TemperatureCelsius = 33.1,
                    Humidity_Percentage = 10,
                    Pressure_Millibar = 9.2
                },
                new WeatherObservation
                {
                    Id=1005,
                    Date = new DateTime(2020, 11, 15, 17, 0, 0),
                    Name = "Atlantis",
                    Latitude = 69.420,
                    Longitude = 69.420,
                    TemperatureCelsius = 20.1,
                    Humidity_Percentage = 100,
                    Pressure_Millibar = 9000.2
                },
                new WeatherObservation
                {
                    Id=1006,
                    Date = new DateTime(2020, 11, 15, 13, 0, 0),
                    Name = "Anna Lises Bar",
                    Latitude = 12.4324,
                    Longitude = 54.1234,
                    TemperatureCelsius = 25.1,
                    Humidity_Percentage = 50,
                    Pressure_Millibar = 900
                });
                
        }
        
    }
}