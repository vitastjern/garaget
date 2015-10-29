using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace garaget_2.Models {
    public class VehicleType {
        [Key]
        public int VehicleTypeId { get; set; }
        public string VehicleTypeName { get; set; }
    }
}