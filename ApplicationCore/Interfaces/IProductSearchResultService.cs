using ExperianTest.ApplicationCore.DTOs;
using System;
using System.Threading.Tasks;

namespace ExperianTest.ApplicationCore.Interfaces
{
    public interface IProductSearchResultService
    {
        Task<ProductSearchResults> GetProductSearchResults(Guid resultsId);
    }
}
