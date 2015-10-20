using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace garaget_2.Models {
    public class Vehicle {
        public int Id { get; set; }
        public string VehicleType { get; set; }
        public string RegNR { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int NRofWheels { get; set; }
    }
}