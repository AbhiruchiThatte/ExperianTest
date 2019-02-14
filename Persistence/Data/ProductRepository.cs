using ExperianTest.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperianTest.Persistence.Data
{
    public class ProductRepository : EfRepository<Product>
    {
        public ProductRepository(CardSearchDbContext context)
                          : base(context)
        { }

        public override async Task<IReadOnlyList<Product>> ListAllAsync()
        {
            IReadOnlyList<Product> products = await base.ListAllAsync();

            foreach (Product product in products)
            {
                product.Rules = _context.ProductRules.Where(pr => pr.ProductId == product.Id).ToList();
            }

            return products;
        }
    }
}
