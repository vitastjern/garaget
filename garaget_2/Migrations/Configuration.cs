namespace garaget_2.Migrations {
    using garaget_2.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<garaget_2.DataAccessLayer.VehicleContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(garaget_2.DataAccessLayer.VehicleContext context) {
            context.Vehicles.AddOrUpdate(v => v.RegNR,
                new Vehicle { RegNR = "ABC123", VehicleType = VehicleTypeList.Bil, Color = "Blå", Brand = "Opel", Model = "Record", NRofWheels = 4,
                              CheckInTime = DateTime.Now.AddDays(-1).AddMinutes(-49).AddSeconds(32)},
                new Vehicle { RegNR = "Gretas", VehicleType = VehicleTypeList.MC, Color = "Flammig", Brand = "HD", Model = "Custom", NRofWheels = 2,
                              CheckInTime = DateTime.Now },
                new Vehicle { RegNR = "FGD234", VehicleType = VehicleTypeList.MC, Color = "Svart", Brand = "Husqvarna", Model = "Militär60", NRofWheels = 3,
                              CheckInTime = DateTime.Now.AddDays(-1).AddHours(+1).AddMinutes(-49).AddSeconds(32)},
                new Vehicle { RegNR = "QRC123", VehicleType = VehicleTypeList.Bil, Color = "Gul", Brand = "VW", Model = "1303s", NRofWheels = 4,
                              CheckInTime = DateTime.Now.AddHours(-4).AddMinutes(-10).AddSeconds(11) 
                } );
        }
    
    }
}
