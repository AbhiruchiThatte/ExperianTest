using ExperianTest.ApplicationCore.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExperianTest.ApplicationCore.Entities
{
    public class Customer : BaseEntity
    {
        public Customer()
        { }

        public Customer(ICustomer customer)
        {
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            DateOfBirth = customer.DateOfBirth;
            AnnualIncome = customer.AnnualIncome;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Column(TypeName="decimal(18,2)")]
        public decimal AnnualIncome { get; set; }
    }
}
