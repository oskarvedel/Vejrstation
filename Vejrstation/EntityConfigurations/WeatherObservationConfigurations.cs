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
                    Id=2,
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
                    Id=3,
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
                    Id=4,
                    Date = new DateTime(2020, 11, 15, 9, 0, 0),
                    Name = "Hjemme paa gaarden",
                    Latitude = 56.158150,
                    Longitude = 10.212030,
                    TemperatureCelsius = 33.1,
                    Humidity_Percentage = 10,
                    Pressure_Millibar = 9.2
                });
        }
        
    }
}