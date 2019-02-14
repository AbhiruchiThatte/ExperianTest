using System;
using System.Collections.Generic;
using System.Text;
using ExperianTest.ApplicationCore.Constants;

namespace ExperianTest.ApplicationCore.Entities
{
    public class Request : BaseEntity
    {
        public Request()
        { }

        public Request(ProductSearchValidationResult result, Customer addedCustomer, int? productId, DateTime dateTimeServed)
        {
            this.ValidationResult = (int)result;
            this.CustomerId = addedCustomer.Id;
            this.ProductId = productId;
            this.RequestServed = dateTimeServed;
            this.UniqueId = Guid.NewGuid();
        }

        public int ValidationResult { get; set; }

        public Customer Customer { get; set; }

        public int CustomerId { get; set; }

        public Product Product { get; set; }

        public int? ProductId { get; set; }

        public DateTime RequestServed { get; set; }

        public Guid UniqueId { get; set; }
    }
}
