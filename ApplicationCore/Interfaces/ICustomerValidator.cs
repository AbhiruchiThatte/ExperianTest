using ExperianTest.ApplicationCore.Constants;
using ExperianTest.ApplicationCore.Entities;

namespace ExperianTest.ApplicationCore.Interfaces
{
    public interface ICustomerValidator
    {
        ProductSearchValidationResult Validate(Customer customerToValidate);
    }
}
