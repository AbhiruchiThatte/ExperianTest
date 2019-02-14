using ExperianTest.ApplicationCore.Entities;
using ExperianTest.ApplicationCore.Validators;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationCore.Tests
{
    [TestFixture]
    public class ProductResultsValidatorTests
    {
        private ProductResultsValidator _productResultsValidator;
        private Customer _customer;
        private List<Product> _products;

        private readonly string BARCLAYCARD_NAME;
        private readonly string VANQUIS_NAME;

        public ProductResultsValidatorTests()
        {
            this.BARCLAYCARD_NAME = "Barclaycard";
            this.VANQUIS_NAME = "Vanquis";
        }

        [SetUp]
        public void SetUp()
        {
            this._productResultsValidator = new ProductResultsValidator();

            this._customer = new Customer();

            _products = new List<Product>();
            _products.Add(new Product
            {
                Name = BARCLAYCARD_NAME,
            });

            _products.Add(new Product
            {
                Name = VANQUIS_NAME,
            });
        }

        [Test]
        public void Income_Zero_ReturnsVanquis()
        {
            this._customer.AnnualIncome = 0;

            var results = _productResultsValidator.ValidateProductsForCustomer(_customer, _products);

            Assert.IsTrue(results.Count() == 1);
            Assert.IsTrue(results.First().Name == VANQUIS_NAME);
        }

        [Test]
        public void Income_Negative_ReturnsVanquis()
        {
            this._customer.AnnualIncome = -10000.00m;

            var results = _productResultsValidator.ValidateProductsForCustomer(_customer, _products);

            Assert.IsTrue(results.Count() == 1);
            Assert.IsTrue(results.First().Name == VANQUIS_NAME);
        }

        [Test]
        public void Income_FortyThousand_ReturnsBarclaycard()
        {
            this._customer.AnnualIncome = 40000.00m;

            var results = _productResultsValidator.ValidateProductsForCustomer(_customer, _products);

            Assert.IsTrue(results.Count() == 1);
            Assert.IsTrue(results.First().Name == BARCLAYCARD_NAME);
        }

        [Test]
        public void Income_ThirtyThousandAndOne_ReturnsBarclaycard()
        {
            this._customer.AnnualIncome = 30000.01m;

            var results = _productResultsValidator.ValidateProductsForCustomer(_customer, _products);

            Assert.IsTrue(results.Count() == 1);
            Assert.IsTrue(results.First().Name == BARCLAYCARD_NAME);
        }

        [Test]
        public void Customer_ThirtyThousand_ReturnsBarclaycard()
        {
            this._customer.AnnualIncome = 30000.00m;

            var results = _productResultsValidator.ValidateProductsForCustomer(_customer, _products);

            Assert.IsTrue(results.Count() == 1);
            Assert.IsTrue(results.First().Name == VANQUIS_NAME);
        }

        [Test]
        public void Income_TwentyThousand_ReturnsVanquis()
        {
            this._customer.AnnualIncome = 20000.00m;

            var results = _productResultsValidator.ValidateProductsForCustomer(_customer, _products);

            Assert.IsTrue(results.Count() == 1);
            Assert.IsTrue(results.First().Name == VANQUIS_NAME);
        }

        [Test]
        public void Income_TwentyNineThousand_ReturnsVanquis()
        {
            this._customer.AnnualIncome = 29999.99m;

            var results = _productResultsValidator.ValidateProductsForCustomer(_customer, _products);

            Assert.IsTrue(results.Count() == 1);
            Assert.IsTrue(results.First().Name == VANQUIS_NAME);
        }
    }
}
