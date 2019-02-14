using ExperianTest.ApplicationCore.Entities;
using ExperianTest.ApplicationCore.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ExperianTest.ApplicationCore.Validators
{
    public class ProductResultsValidator : IProductResultsValidator
    {
        private readonly string BARCLAYCARD_NAME;
        private readonly string VANQUIS_NAME;


        public ProductResultsValidator()
        {
            this.BARCLAYCARD_NAME = "Barclaycard";
            this.VANQUIS_NAME = "Vanquis";
        }

        public IEnumerable<Product> ValidateProductsForCustomer(Customer customer, IEnumerable<Product> products)
        {
            List<Product> validProducts;

            // test says over £30,000, not £30,000 or more - would ask for clarity in real situation
            if (customer.AnnualIncome > 30000.00m)
            {
                validProducts = GetProductAndAddToList(products, BARCLAYCARD_NAME);
            }
            else
            {
                validProducts = GetProductAndAddToList(products, VANQUIS_NAME);
            }

            return validProducts;
        }

        private List<Product> GetProductAndAddToList(IEnumerable<Product> products, string cardName)
        {
            List<Product> validProducts = new List<Product>();

            var product = products.ToList().Find(p => p.Name == cardName);
            if (product != null)
            {
                validProducts.Add(product);
            }

            return validProducts;
        }
    }
}
