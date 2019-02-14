using ExperianTest.ApplicationCore.DTOs;
using ExperianTest.ApplicationCore.Entities;
using ExperianTest.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExperianTest.ApplicationCore.Services
{
    public class ProductSearchResultService : IProductSearchResultService
    {
        private IRequestRepository _requestRepo;
        private IAsyncRepository<Customer> _customerRepo;
        private IAsyncRepository<Product> _productRepo;

        public ProductSearchResultService(IRequestRepository requestRepo, 
                                          IAsyncRepository<Customer> customerRepo, IAsyncRepository<Product> productRepo)
        {
            this._requestRepo = requestRepo;
            this._customerRepo = customerRepo;
            this._productRepo = productRepo;
        }

        public async Task<ProductSearchResults> GetProductSearchResults(Guid resultsId)
        {
            Request request = await _requestRepo.GetRequestByGuidAsync(resultsId);

            ProductSearchResults results = null;
            if (request != null && request.ProductId != null)
            {
                Customer customer = await _customerRepo.GetByIdAsync(request.CustomerId);

                var product = await _productRepo.GetByIdAsync((int)request.ProductId);

                results = new ProductSearchResults(customer, new List<Product> { product });
            }

            return results;
        }
    }
}
