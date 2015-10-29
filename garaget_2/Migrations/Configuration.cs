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
                new Member { MemberId = 1, FirstName = "Niklas", LastName = "Säwensten", Street = "Greatway 49", PostalCode = "55555", City = "TimmerÖn" },
                new Member { MemberId = 2, FirstName = "Kenneth", LastName = "Forsström", Street = "Genvägen 3", PostalCode = "333333", City = "Mörka Skogen" },
                new Member { MemberId = 3, FirstName = "Anna", LastName = "Eklund", Street = "Hemvägen 5", PostalCode = "11234", City = "Staden" },
                new Member { MemberId = 4, FirstName = "Bo", LastName = "Ek", Street = "Away 1", PostalCode = "55555", City = "Köping" },
                new Member { MemberId = 5, FirstName = "Ulla", LastName = "Ölund", Street = "Senvägen 17", PostalCode = "45676", City = "Enköping" },
                new Member { MemberId = 6, FirstName = "Bella", LastName = "Skog", Street = "Kortgränd ½", PostalCode = "11111", City = "Tvåköping" }
                );

            context.Vehicles.AddOrUpdate(v => v.RegNr,
                new Vehicle
                {
                    VehicleId = 1,
                    RegNr = "Vinsten",
                    Color = "Silvermetallic",
                    Brand = "Fård",
                    Model = "350",
                    NrOfWheels = 4,
                    MemberId = 2,
                    VehicleTypeId = 2,
                    CheckInTime = DateTime.Now.AddDays(-4).AddMinutes(-29).AddSeconds(13)
                },
                new Vehicle
                {
                    VehicleId = 2,
                    RegNr = "Annas",
                    Color = "Blå",
                    Brand = "Opel",
                    Model = "Record",
                    NrOfWheels = 4,
                    MemberId = 3,
                    VehicleTypeId = 7,
                    CheckInTime = DateTime.Now.AddDays(-1).AddMinutes(-45).AddSeconds(33)
                },
                new Vehicle
                {
                    VehicleId = 3,
                    RegNr = "FGR456",
                    Color = "Grön",
                    Brand = "VW",
                    Model = "1300 s",
                    NrOfWheels = 4,
                    MemberId = 4,
                    VehicleTypeId = 1,
                    CheckInTime = DateTime.Now.AddDays(-2).AddMinutes(-56).AddSeconds(36)
                },
                new Vehicle
                {
                    VehicleId = 4,
                    RegNr = "Annas",
                    Color = "Blå",
                    Brand = "Opel",
                    Model = "Record",
                    NrOfWheels = 4,
                    MemberId = 5,
                    VehicleTypeId = 7,
                    CheckInTime = DateTime.Now.AddDays(-1).AddMinutes(-10).AddSeconds(10)
                },
                new Vehicle
                {
                    VehicleId = 4,
                    RegNr = "20020229-0229",
                    Color = "Blå-vit-svart",
                    Brand = "Cresent",
                    Model = "Herr",
                    NrOfWheels = 2,
                    MemberId = 4,
                    VehicleTypeId = 6,
                    CheckInTime = DateTime.Now.AddDays(-1).AddMinutes(-10).AddSeconds(10)
                },
                new Vehicle
                {
                    VehicleId = 5,
                    RegNr = "ABC123",
                    Color = "Blå",
                    Brand = "Opel",
                    Model = "Record",
                    NrOfWheels = 4,
                    MemberId = 6,
                    VehicleTypeId = 1,
                    CheckInTime = DateTime.Now.AddDays(-1).AddMinutes(-49).AddSeconds(3)
                });
        }
    }
}
