using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using mlmanagment1.Models;

namespace mlmanagment1.ViewModel
{
    public class NewCustomerViewModel
    {
        public string Title;
     //   public IEnumerable<OffertType> OffertTypeId1 { get; set; }
        public IEnumerable<OffertType> OffertType { get; set; }
        public Customer Customer { get; set; }
       
        public byte? OffertTypeId { get; set; }

        ////all customer
        //public int Id { set; get; }
        //[Required]
        //[Display(Name = "Fist Name")]
        //public string FirstName { get; set; }
        //public string MiddleName { get; set; }

        //[Required]
        //[Display(Name = "Last name")]
        //public string LastName { get; set; }

        //public byte OffertTypeId1 { get; set; }
        //public string Comment { get; set; }
        //[Display(Name = "Completed")]
        //public bool DocumentIsComplete { get; set; }
        //public DateTime? Birthdate { get; set; }
        //[Display(Name = "Registration Date")]
        //public DateTime RegistrationDate { get; set; }


       
    }
}
