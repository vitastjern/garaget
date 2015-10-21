namespace garaget_2.Migrations
{
    using garaget_2.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<garaget_2.DataAccessLayer.VehicleContext>
    {
                public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(garaget_2.DataAccessLayer.VehicleContext context)
        {
            context.Vehicles.AddOrUpdate(v => v.RegNR,
                new Vehicle { RegNR = "ABC123", VehicleType = "Bil", Color = "Blå",
                              Brand = "Opel",
                              Model = "Record",
                              NRofWheels = 4,
                              CheckInTime = DateTime.Now.AddDays(-1).AddMinutes(-49).AddSeconds(32)
                },
                new Vehicle { RegNR = "PRC123", VehicleType = "Bil", Color = "Gul",
                              Brand = "VW",
                              Model = "1303s",
                              NRofWheels = 4,
                              CheckInTime = DateTime.Now
                });        
        }
    
    }
}
