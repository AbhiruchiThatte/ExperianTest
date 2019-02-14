using ExperianTest.ApplicationCore.DTOs;
using ExperianTest.ApplicationCore.Entities;
using System.Threading.Tasks;

namespace ExperianTest.ApplicationCore.Interfaces
{
    public interface IProductSearchService
    {
        Task<ProductSearchResponse> GetProductsForCustomer(Customer customerToAdd);
    }
}