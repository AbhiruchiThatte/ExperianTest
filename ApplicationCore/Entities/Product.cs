using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExperianTest.ApplicationCore.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {
            this.Rules = new List<ProductRule>();
        }

        public string Name { get; set; }

        [Column(TypeName="decimal(5,2)")]
        public decimal Apr { get; set; }

        public string PromotionalMessage { get; set; }

        public string ImageUrl { get; set; }

        public List<ProductRule> Rules { get; set; }
    }
}
