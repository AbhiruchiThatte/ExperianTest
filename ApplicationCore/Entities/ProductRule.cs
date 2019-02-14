using ExperianTest.ApplicationCore.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExperianTest.ApplicationCore.Entities
{
    public class ProductRule : BaseEntity
    {
        public int ProductId { get; set; }

        public ProductRuleType RuleType { get; set; }

        public int RuleValue { get; set; }
    }
}
