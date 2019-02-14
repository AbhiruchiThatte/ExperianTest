using ExperianTest.ApplicationCore.Constants;
using ExperianTest.ApplicationCore.DTOs;
using ExperianTest.ApplicationCore.Entities;
using ExperianTest.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using ExperianTest.Web.Models;
using System;
using ExperianTest.Web.Resources;

namespace ExperianTest.Web.Pages.Products
{
    public class CardSearchModel : PageModel
    {
        private readonly IProductSearchService _customerService;

        [BindProperty]
        public CustomerModel Customer { get; set; }

        public CardSearchModel(IProductSearchService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult OnGet()
        {
            ViewData["Title"] = "Search Products";

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var customer = new Customer(this.Customer);

            ProductSearchResponse result = await _customerService.GetProductsForCustomer(customer);

            if (result.ValidationResult != ProductSearchValidationResult.Valid)
            {
                string errorMessage = GetErrorMessage(result.ValidationResult);
                ModelState.AddModelError(Constants.VALIDATION_ERROR_KEY, errorMessage);

                return Page();
            }
            
            // pass the request id to retrieve the request results
            // ideally would use authentication
            return RedirectToPage("./CardResults", new { id = result.ResultsId.ToString() });
        }

        private string GetErrorMessage(ProductSearchValidationResult validationResult)
        {
            switch (validationResult)
            {
                case ProductSearchValidationResult.UnderEighteen:
                    {
                        return ProductSearchStringResources.UnderAgeValidationError;
                    }
                default:
                    {
                        return ProductSearchStringResources.DefaultValidationError;
                    }
            }
        }
    }
}