using ExperianTest.ApplicationCore.DTOs;
using ExperianTest.ApplicationCore.Constants;
using ExperianTest.ApplicationCore.Entities;
using ExperianTest.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExperianTest.ApplicationCore.Services
{
    public class ProductSearchService : IProductSearchService
    {
        private IAsyncRepository<Customer> _customerRepo;
        private IAsyncRepository<Product> _productRepo;
        private IAsyncRepository<Request> _requestRepo;

        private ICustomerValidator _customerValidator;
        private IProductResultsValidator _productResultsValidator;
        private ICustomerDetailsFormatter _customerDetailsFormatter;

        public ProductSearchService(IAsyncRepository<Customer> customerRepo, IAsyncRepository<Product> productRepo,
                                    IAsyncRepository<Request> requestRepo,
                                    ICustomerValidator customerValidator, IProductResultsValidator productResultsValidator,
                                    ICustomerDetailsFormatter customerDetailsFormatter)
        {
            this._customerRepo = customerRepo;
            this._productRepo = productRepo;
            this._requestRepo = requestRepo;

            this._customerValidator = customerValidator;
            this._productResultsValidator = productResultsValidator;

            this._customerDetailsFormatter = customerDetailsFormatter;
        }

        public async Task<ProductSearchResponse> GetProductsForCustomer(Customer customerToAdd)
        {
            customerToAdd = _customerDetailsFormatter.Format(customerToAdd);

            Customer addedCustomer = await _customerRepo.AddAsync(customerToAdd);

            ProductSearchValidationResult result = _customerValidator.Validate(addedCustomer);

            IEnumerable<Product> productResults = await GetProductsForCustomer(result, addedCustomer);

            Request request = await RecordSearch(result, addedCustomer, productResults);

            ProductSearchResponse response = new ProductSearchResponse(result, request.UniqueId);

            return response;
        }

        private async Task<IEnumerable<Product>> GetProductsForCustomer(ProductSearchValidationResult result, Customer addedCustomer)
        {
            IEnumerable<Product> productResults = new List<Product>();
            if (result == ProductSearchValidationResult.Valid)
            {
                // do a product search
                IReadOnlyList<Product> products = await _productRepo.ListAllAsync();
                productResults = _productResultsValidator.ValidateProductsForCustomer(addedCustomer, products);
            }

            return productResults;
        }

        private async Task<Request> RecordSearch(ProductSearchValidationResult result, Customer addedCustomer, IEnumerable<Product> productResults)
        {
            // if multiple products were being returned and I wanted to record each
            // I would need another table for returned products that would be stored
            // against the requestId

            var product = productResults.FirstOrDefault();

            int? productId = null;
            if (product != null)
            {
                productId = product.Id; ;
            }

            var request = new Request(result, addedCustomer, productId, DateTime.Now);

            request = await _requestRepo.AddAsync(request);

            return request;
        }
    }
}