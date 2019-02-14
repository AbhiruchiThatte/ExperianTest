using ExperianTest.ApplicationCore.Entities;
using System.Collections.Generic;

namespace ExperianTest.ApplicationCore.Interfaces
{
    public interface IProductResultsValidator
    {
        IEnumerable<Product> ValidateProductsForCustomer(Customer customer, IEnumerable<Product> products);
    }
}