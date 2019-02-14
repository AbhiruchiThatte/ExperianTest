using ExperianTest.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExperianTest.Web.Models
{
    public class ProductSearchResultModel
    {
        public ProductSearchResultModel(Customer customer, IEnumerable<Product> products)
        {
            this.CustomerFirstName = customer.FirstName;
            this.SearchResults = products;
        }

        public string CustomerFirstName { get; set; }

        public IEnumerable<Product> SearchResults{ get; set; }
    }
}
