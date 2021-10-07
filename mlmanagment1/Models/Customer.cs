using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mlmanagment1.Models
{
    public class Customer
    {
        public int Id { set; get; }
        [Required]
        [Display(Name ="Fist Name")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        [Display(Name ="Last name")]
        public string LastName { get; set; }


        public int OffertTypeId { get; set; }
        public OffertType OffertType { get; set; }


        public string Comment { get; set; }
        [Display(Name = "Completed")]
        public bool DocumentIsComplete { get; set; }
        public DateTime? Birthdate { get; set; }
        [Display(Name = "Registration Date")]
        public DateTime RegistrationDate { get; set; } 

    }
}
