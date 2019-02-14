using ExperianTest.ApplicationCore.Constants;
using System;

namespace ExperianTest.ApplicationCore.DTOs
{
    public class ProductSearchResponse
    {
        public ProductSearchResponse(ProductSearchValidationResult result, Guid resultsId)
        {
            this.ValidationResult = result;
            this.ResultsId = resultsId;
        }

        public ProductSearchValidationResult ValidationResult { get; }

        public Guid ResultsId { get; }
    }
}
