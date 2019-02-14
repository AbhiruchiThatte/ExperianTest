using ExperianTest.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;
using System.Threading.Tasks;
using ExperianTest.Web.Models;

namespace ExperianTest.Web.Pages.Products
{
    public class CardResultsModel : PageModel
    {
        private IProductSearchResultService _productResultService;

        [BindProperty]
        public ProductSearchResultModel Results { get; set; }

        public CardResultsModel(IProductSearchResultService productResultService)
        {
            this._productResultService = productResultService;
        }

        public async Task<IActionResult> OnGet(string id)
        {
            ViewData["Title"] = "Search Results";

            Guid resultsGuid;
            if (string.IsNullOrEmpty(id)
                || Guid.TryParse(id, out resultsGuid) == false)
            {
                return RedirectToPage("./CardSearch");
            }

            var results = await _productResultService.GetProductSearchResults(resultsGuid);

            if (results == null)
            {
                return RedirectToPage("./CardSearch");
            }

            this.Results = new ProductSearchResultModel(results.Customer, results.Products);

            return Page();
        }
    }
}