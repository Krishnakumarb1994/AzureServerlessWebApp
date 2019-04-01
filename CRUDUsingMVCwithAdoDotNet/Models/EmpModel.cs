using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDUsingMVC.Models
{
    public class EmpModel
    {
        [Display(Name ="Id")]
      
        public int Empid { get; set; }

        [Required(ErrorMessage ="First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        public string Age { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        public string DateofBirth { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string  Address { get; set; }

        [Required(ErrorMessage = "Is Active is required.")]
        public string IsActive { get; set; }

    }
}