namespace garaget_2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<garaget_2.DataAccessLayer.VehicleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(garaget_2.DataAccessLayer.VehicleContext context)
        {
            context.Vehicles.AddOrUpdate(v => v.RegNR,
                new Vehicle { RegNR = "ABC123", VehicleType = "Bil", Color = "Blå", Brand = "Opel", Model = "Record", NRofWheels = 4 },
                new Vehicle { RegNR = "QRC123", VehicleType = "Bil", Color = "Gul", Brand = "VW", Model = "1303s", NRofWheels = 4 });        
        }
    }
}
