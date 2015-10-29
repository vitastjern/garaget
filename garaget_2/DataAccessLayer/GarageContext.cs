using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using garaget_2.Models;


namespace garaget_2.DataAccessLayer {
    public class GarageContext :DbContext {
        public GarageContext() : base("GarageContext") { }

        public DbSet<Member> Members { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
    }
}