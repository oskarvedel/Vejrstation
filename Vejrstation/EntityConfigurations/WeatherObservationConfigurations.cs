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
            });
        }
        
    }
}