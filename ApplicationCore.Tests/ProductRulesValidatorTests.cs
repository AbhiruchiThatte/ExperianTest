using ExperianTest.ApplicationCore.Constants;
using ExperianTest.ApplicationCore.Entities;
using ExperianTest.ApplicationCore.Validators;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationCore.Tests
{
    [TestFixture]
    public class ProductRulesValidatorTests
    {
        private ProductRulesValidator _validator;
        private List<Product> _products;
        private Customer _customer;
        private ProductRule _rule;
        private readonly string BARCLAYCARD_NAME;
        private readonly string VANQUIS_NAME;

        public ProductRulesValidatorTests()
        {
            this.BARCLAYCARD_NAME = "Barclaycard";
            this.VANQUIS_NAME = "Vanquis";
        }

        [SetUp]
        public void SetUp()
        {
            this._validator = new ProductRulesValidator();
            this._customer = new Customer();

            this._rule = new ProductRule
            {
                ProductId = 1,
                RuleType = ProductRuleType.MinimumIncome,
                RuleValue = 30000
            };

            this._products = new List<Product>()
            {
                new Product
                {
                    Name = "Barclaycard",
                    Apr = 15.00m,
                    PromotionalMessage = "Just right.",
                    ImageUrl = "/images/barclaycard.png",
                    Rules = new List<ProductRule>()
                    {
                        _rule,
                    }
                },
                new Product
                {
                    Name = "Vanquis",
                    Apr = 30.15m,
                    PromotionalMessage = "That's the ticket.",
                    ImageUrl = "/images/vanquiscard.png"
                }
            };
        }

        [Test]
        public void Income_Zero_ReturnsVanquis()
        {
            this._customer.AnnualIncome = 0;

            var results = _validator.ValidateProductsForCustomer(_customer, _products);

            Assert.IsTrue(results.Count() == 1);
            Assert.IsTrue(results.First().Name == VANQUIS_NAME);
        }

        [Test]
        public void Income_Negative_ReturnsVanquis()
        {
            this._customer.AnnualIncome = -10000.00m;

            var results = _validator.ValidateProductsForCustomer(_customer, _products);

            Assert.IsTrue(results.Count() == 1);
            Assert.IsTrue(results.First().Name == VANQUIS_NAME);
        }

        [Test]
        public void Income_FortyThousand_ReturnsBarclaycard()
        {
            this._customer.AnnualIncome = 40000.00m;

            var results = _validator.ValidateProductsForCustomer(_customer, _products);

            Assert.IsTrue(results.Count() == 1);
            Assert.IsTrue(results.First().Name == BARCLAYCARD_NAME);
        }

        [Test]
        public void Income_ThirtyThousandAndOne_ReturnsBarclaycard()
        {
            this._customer.AnnualIncome = 30000.01m;

            var results = _validator.ValidateProductsForCustomer(_customer, _products);

            Assert.IsTrue(results.Count() == 1);
            Assert.IsTrue(results.First().Name == BARCLAYCARD_NAME);
        }

        [Test]
        public void Customer_ThirtyThousand_ReturnsBarclaycard()
        {
            this._customer.AnnualIncome = 30000.00m;

            var results = _validator.ValidateProductsForCustomer(_customer, _products);

            Assert.IsTrue(results.Count() == 1);
            Assert.IsTrue(results.First().Name == VANQUIS_NAME);
        }

        [Test]
        public void Income_TwentyThousand_ReturnsVanquis()
        {
            this._customer.AnnualIncome = 20000.00m;

            var results = _validator.ValidateProductsForCustomer(_customer, _products);

            Assert.IsTrue(results.Count() == 1);
            Assert.IsTrue(results.First().Name == VANQUIS_NAME);
        }

        [Test]
        public void Income_TwentyNineThousand_ReturnsVanquis()
        {
            this._customer.AnnualIncome = 29999.99m;

            var results = _validator.ValidateProductsForCustomer(_customer, _products);

            Assert.IsTrue(results.Count() == 1);
            Assert.IsTrue(results.First().Name == VANQUIS_NAME);
        }
    }
}
