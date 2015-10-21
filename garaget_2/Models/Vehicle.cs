using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace garaget_2.Models {
    public class Vehicle {
        public int Id { get; set; }

        [Display(Name = "Fordonstyp")]
        public string VehicleType { get; set; }

        [Display(Name = "Regnummer")]
        public string RegNR { get; set; }

        [Display(Name="Färg")]
        public string Color { get; set; }

        [Display(Name="Märke")]
        public string Brand { get; set; }
        
        [Display(Name="Modell")]
        public string Model { get; set; }

        [Display(Name="Antal hjul")]
        public int NRofWheels { get; set; }
    }
}