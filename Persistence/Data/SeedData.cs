using ExperianTest.ApplicationCore.Entities;
using ExperianTest.ApplicationCore.Constants;
using ExperianTest.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Persistence.Data
{
    public static class SeedData
    {
        public static void Initialise(IServiceProvider serviceProvider)
        {
            var options = serviceProvider.GetRequiredService<DbContextOptions<CardSearchDbContext>>();
            using (var context = new CardSearchDbContext(options))
            {
                SeedProducts(context);
                SeedProductRules(context);
            }
        }

        private static void SeedProducts(CardSearchDbContext context)
        {
            if (context.Products.Any())
            {
                return;
            }
            else
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Barclaycard",
                        Apr = 15.00m,
                        PromotionalMessage = "Just right.",
                        ImageUrl = "/images/barclaycard.png"
                    },
                    new Product
                    {
                        Name = "Vanquis",
                        Apr = 30.15m,
                        PromotionalMessage = "That's the ticket.",
                        ImageUrl = "/images/vanquiscard.png"
                    });
                context.SaveChanges();
            }
        }

        private static void SeedProductRules(CardSearchDbContext context)
        {
            if (context.ProductRules.Any())
            {
                return;
            }
            else
            {
                context.ProductRules.AddRange(
                    new ProductRule
                    {
                        ProductId = 1,
                        RuleType = ProductRuleType.MinimumIncome,
                        RuleValue = 30000,
                    });
                context.SaveChanges();
            }
        }
    }
}
