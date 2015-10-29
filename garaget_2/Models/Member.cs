using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace garaget_2.Models {
    public class Member {

        [Display(Name="Medlemsnummer")]
        public int MemberId { get; set; }

        [Display(Name="Förnamn")]
        public string FirstName { get; set; }

        [Display(Name="Efternamn")]
        public string LastName { get; set; }

        [Display(Name="Gatuadress")]
        public string Street { get; set; }

        [Display(Name="Postnummer")]
        public string PostalCode { get; set; }

        [Display(Name="Ort")]
        public string City { get; set; }

        [Display(Name = "Namn")]
        public string FullName {
            get {
                var fullName = FirstName + " " + LastName;
                fullName.Trim();
                return fullName;
            }
        }

        [Display(Name="Adress")]
        public string Address
        {
            get
            {
                var address = Street + ", " + PostalCode + " " + City;
                address.Trim();
                return address;
            }
        }
    }
}