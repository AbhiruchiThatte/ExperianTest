using ExperianTest.ApplicationCore.Entities;

namespace ExperianTest.ApplicationCore.Interfaces
{
    public interface ICustomerDetailsFormatter
    {
        Customer Format(Customer customer);
    }
}
