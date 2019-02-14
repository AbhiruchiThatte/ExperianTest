using ExperianTest.ApplicationCore.Constants;
using ExperianTest.ApplicationCore.Entities;
using ExperianTest.ApplicationCore.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ExperianTest.ApplicationCore.Validators
{
    public class ProductRulesValidator : IProductResultsValidator
    {
        public IEnumerable<Product> ValidateProductsForCustomer(Customer customer, IEnumerable<Product> products)
        {
            List<Product> validProducts = GetValidProducts(customer, products);

            validProducts = RemoveProductsIfRulesApplied(validProducts);

            return validProducts;
        }

        private List<Product> GetValidProducts(Customer customer, IEnumerable<Product> products)
        {
            var validProducts = new List<Product>();

            foreach (Product product in products)
            {
                bool validProduct = true;

                // check each rule is valid for the customer
                foreach (ProductRule rule in product.Rules)
                {
                    bool valid = ValidateRule(rule, customer);

                    if (valid == false)
                    {
                        validProduct = false;
                        break;
                    }
                }

                if (validProduct)
                {
                    // all the rules passed
                    validProducts.Add(product);
                }
            }

            return validProducts;
        }

        private bool ValidateRule(ProductRule rule, Customer customer)
        {
            bool valid = false;
            
            switch (rule.RuleType)
            {
                case ProductRuleType.MinimumIncome:
                    {
                        if (customer.AnnualIncome > rule.RuleValue)
                        {
                            valid = true;
                        }

                        break;
                    }
            }

            return valid;
        }

        /// <summary>
        /// Removes less selective rules
        /// </summary>
        /// <param name="validProducts"></param>
        /// <returns></returns>
        private List<Product> RemoveProductsIfRulesApplied(List<Product> validProducts)
        {
            if (validProducts.Any(r => r.Rules.Count > 0))
            {
                validProducts.RemoveAll(p => p.Rules.Count == 0);
            }

            return validProducts;
        }
    }
}
