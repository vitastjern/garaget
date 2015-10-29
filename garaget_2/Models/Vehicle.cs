using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace garaget_2.Models {

    public class Vehicle {
        [Key]
        public int VehicleId { get; set; }

        [Display(Name = "Reg.identitet")]
        [Required(ErrorMessage = "Fråga efter legitimation, istället?")]
        [RegularExpression("^[a-zA-ZöäåÖÄÅ &%§.,-;:0-9]*$", ErrorMessage = "Programmeringstecken etc. är ej tillåtna!")]
        [MinLength(4, ErrorMessage = ("Enlig Wiki kan man inte identifiera det ni skrev!"))]
        [MaxLength(32, ErrorMessage = "Det här är inte rätt ställe att skriva noveller!")]
        public string RegNr { get; set; }

        [Display(Name = "Färg")]
        [RegularExpression("^[a-zA-ZöäåÖÄÅ &%§.,-;:0-9]*$", ErrorMessage = "Programmeringstecken etc. är ej tillåtna!")]
        [MinLength(3, ErrorMessage = "Vit, röd, blå, gul, blå & grå är korta färgnamn")]
        [MaxLength(32, ErrorMessage = "Det här är inte rätt ställe att skriva noveller!")]
        public string Color { get; set; }

        [Display(Name = "Märke")]
        [RegularExpression("^[a-zA-ZöäåÖÄÅ &%§.,-;:0-9]*$", ErrorMessage = "Programmeringstecken etc. är ej tillåtna!")]
        [MinLength(2, ErrorMessage = "Om ni anger något, skriv vettigt!")]
        [MaxLength(32, ErrorMessage = "Det här är inte rätt ställe att skriva noveller!")]
        public string Brand { get; set; }

        [Display(Name = "Modell")]
        [RegularExpression("^[a-zA-ZöäåÖÄÅ &%§.,-;:0-9]*$", ErrorMessage = "Programmeringstecken etc. är ej tillåtna!")]
        [MinLength(2, ErrorMessage = "I denna värld finns inte så korta modellnamn")]
        [MaxLength(32, ErrorMessage = "Det här är inte rätt ställe att skriva noveller!")]
        public string Model { get; set; }

        [Display(Name = "Antal hjul")]
        [Range(1, 999, ErrorMessage = "Stridsvagnar/snöfordon med band skadar golvet. Hjul krävs!")]
        public int NrOfWheels { get; set; }

        [Display(Name = "Tidpunkt för incheckning")]
        public DateTime CheckInTime { get; set; }

        public int MemberId { get; set; }
        public int VehicleTypeId { get; set; }

        public virtual Member Member { get; set; }
        public virtual VehicleType VehicleType { get; set; }
    }
}