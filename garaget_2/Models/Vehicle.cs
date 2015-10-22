using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace garaget_2.Models {
    //public enum VehicleTypeList { Cykel, MC, Bil, SUV, Limousine, Bil_m_släp, Lastbil, Buss }
    public enum VehicleTypeList { Bil, SUV, Limousine, MC, Cykel, Bil_m_släp, Lastbil, Buss, Annan }

    public class Vehicle {
        public int Id { get; set; }

        [Display(Name = "Fordonstyp")]
        public VehicleTypeList VehicleType { get; set; }

        [Display(Name = "Reg.identitet")]
        [Required(ErrorMessage = "Fråga efter legitimation, istället?")]
        [MinLength(4, ErrorMessage = ("Enlig Wiki kan man inte identifiera det ni skrev!"))]
        [MaxLength(32, ErrorMessage = "Det här är inte rätt ställe att skriva noveller!")]
        public string RegNR { get; set; }

        [Display(Name = "Färg")]
        [MinLength(3, ErrorMessage = "Vit, röd, blå, gul, blå & grå är korta färgnamn")]
        [MaxLength(32, ErrorMessage = "Det här är inte rätt ställe att skriva noveller!")]
        public string Color { get; set; }

        [Display(Name = "Märke")]
        [MinLength(2, ErrorMessage = "Om ni anger något, skriv vettigt!")]
        [MaxLength(32, ErrorMessage = "Det här är inte rätt ställe att skriva noveller!")]
        public string Brand { get; set; }

        [Display(Name = "Modell")]
        [MinLength(2, ErrorMessage = "I denna värld finns inte så korta modellnamn")]
        [MaxLength(32, ErrorMessage = "Det här är inte rätt ställe att skriva noveller!")]
        public string Model { get; set; }

        [Display(Name = "Antal hjul")]
        [Range(1, 22, ErrorMessage = "Stridsvagnar & snöfordon skadar golvet, hjul krävs!")]
        public int NRofWheels { get; set; }

        [Display(Name = "Tidpunkt för incheckning")]
        public DateTime CheckInTime { get; set; }
    }
}