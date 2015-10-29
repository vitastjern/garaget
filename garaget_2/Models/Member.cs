using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace garaget_2.Models {
    public class Member {
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        public string FullName {
            get {
                var fullName = FirstName + " " + LastName;
                fullName.Trim();
                return fullName;
            }
        }
    }
}