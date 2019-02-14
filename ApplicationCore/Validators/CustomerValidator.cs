using ExperianTest.ApplicationCore.Constants;
using ExperianTest.ApplicationCore.Entities;
using ExperianTest.ApplicationCore.Interfaces;
using System;

namespace ExperianTest.ApplicationCore.Validators
{
    public class CustomerValidator : ICustomerValidator
    {
        public ProductSearchValidationResult Validate(Customer customerToValidate)
        {
            var result = ProductSearchValidationResult.NotSet;

            if (customerToValidate.DateOfBirth > DateTime.Today.AddYears(-18))
            {
                result = ProductSearchValidationResult.UnderEighteen;
            }
            else
            {
                result = ProductSearchValidationResult.Valid;
            }

            return result;
        }
    }
}
