using System;
using System.Collections.Generic;
using System.Text;

namespace ExperianTest.ApplicationCore.Interfaces
{
    public interface ICustomer
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime DateOfBirth { get; set; }
        decimal AnnualIncome { get; set; }
    }
}
