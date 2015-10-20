using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace garaget_2.DataAccessLayer {
    public class VehicleContext : DbContext {
        public VehicleContext() : base("DefaultConnection") { }
        public DbSet<Models.Vehicle> Vehicles { get; set; }
    }
}