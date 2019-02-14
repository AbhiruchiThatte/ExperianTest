using ExperianTest.ApplicationCore.Constants;
using ExperianTest.ApplicationCore.Entities;
using ExperianTest.ApplicationCore.Validators;
using NUnit.Framework;
using System;

namespace Tests
{
    public class Tests
    {
        private CustomerValidator _validator;

        [SetUp]
        public void Setup()
        {
            this._validator = new CustomerValidator();
        }

        [Test]
        public void Customer_EighteenYesterday_ReturnsValid()
        {
            Customer customer = new Customer();
            customer.DateOfBirth = DateTime.Today.AddYears(-18).AddDays(-1);

            var result = _validator.Validate(customer);
            Assert.IsTrue(result == ProductSearchValidationResult.Valid);
        }

        [Test]
        public void Customer_EighteenToday_ReturnsValid()
        {
            Customer customer = new Customer();
            customer.DateOfBirth = DateTime.Today.AddYears(-18);

            var result = _validator.Validate(customer);
            Assert.IsTrue(result == ProductSearchValidationResult.Valid);
        }


        [Test]
        public void Customer_UnderEighteenYears_ReturnsNotValid()
        {
            Customer customer = new Customer();
            customer.DateOfBirth = DateTime.Today.AddYears(-18).AddDays(1);

            var result = _validator.Validate(customer);
            Assert.IsTrue(result == ProductSearchValidationResult.UnderEighteen);
        }
    }
}