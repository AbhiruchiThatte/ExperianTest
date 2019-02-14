
using ExperianTest.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExperianTest.Web.Models
{
    public class CustomerModel : ICustomer
    {
        public CustomerModel()
        {
            this.FirstName = string.Empty;
            this.LastName = string.Empty;
        }

        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth:")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Annual income is required")]
        [Display(Name = "Annual Income (£):")]
        [DataType(DataType.Currency)]
        public decimal AnnualIncome { get; set; }
    }
}
