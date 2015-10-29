namespace garaget_2.Migrations {
    using garaget_2.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<garaget_2.DataAccessLayer.GarageContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(garaget_2.DataAccessLayer.GarageContext context) {


            context.VehicleTypes.AddOrUpdate(vt => vt.VehicleTypeName,

            new VehicleType { VehicleTypeId = 1, VehicleTypeName = "Bil" },
            new VehicleType { VehicleTypeId = 2, VehicleTypeName = "MC" },
            new VehicleType { VehicleTypeId = 3, VehicleTypeName = "SUV" },
            new VehicleType { VehicleTypeId = 4, VehicleTypeName = "Buss" },
            new VehicleType { VehicleTypeId = 5, VehicleTypeName = "Lastbil" },
            new VehicleType { VehicleTypeId = 6, VehicleTypeName = "Cykel" },
            new VehicleType { VehicleTypeId = 7, VehicleTypeName = "UFO" },
            new VehicleType { VehicleTypeId = 8, VehicleTypeName = "Annat" }
          );

            context.Members.AddOrUpdate(m => m.FirstName,
                new Member { MemberId = 1, FirstName = "Niklas", LastName = "S�wensten", Street = "Greatway 49", PostalCode = "55555", City = "Timmer�n" },
                new Member { MemberId = 2, FirstName = "Kenneth", LastName = "Forsstr�m", Street = "Genv�gen 3", PostalCode = "333333", City = "M�rka Skogen" },
                new Member { MemberId = 3, FirstName = "Anna", LastName = "Eklund", Street = "Hemv�gen 5", PostalCode = "11111", City = "Staden" }
                );

            context.Vehicles.AddOrUpdate(v => v.RegNr,
                new Vehicle
                {
                    RegNr = "Vinsten",
                    Color = "Silvermetallic",
                    Brand = "F�rd",
                    Model = "350",
                    NrOfWheels = 4,
                    MemberId = 3,
                    VehicleTypeId = 2,
                    CheckInTime = DateTime.Now.AddDays(-4).AddMinutes(-29).AddSeconds(13)
                },
                new Vehicle
                {
                    RegNr = "Annas",
                    Color = "Bl�",
                    Brand = "Opel",
                    Model = "Record",
                    NrOfWheels = 4,
                    MemberId = 3,
                    VehicleTypeId = 7,
                    CheckInTime = DateTime.Now.AddDays(-1).AddMinutes(-49).AddSeconds(33)
                },
                new Vehicle
                {
                    RegNr = "ABC123",
                    Color = "Bl�",
                    Brand = "Opel",
                    Model = "Record",
                    NrOfWheels = 4,
                    MemberId = 1,
                    VehicleTypeId = 1,
                    CheckInTime = DateTime.Now.AddDays(-1).AddMinutes(-49).AddSeconds(3)
                });
        }
    }
}
