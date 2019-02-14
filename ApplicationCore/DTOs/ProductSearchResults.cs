using ExperianTest.ApplicationCore.Entities;
using System.Collections.Generic;

namespace ExperianTest.ApplicationCore.DTOs
{
    public class ProductSearchResults
    {
        public ProductSearchResults(Customer customer, List<Product> products)
        {
            this.Customer = customer;
            this.Products = products;
        }

        public Customer Customer { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
