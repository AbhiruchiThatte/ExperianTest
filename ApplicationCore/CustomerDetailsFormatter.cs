using ExperianTest.ApplicationCore.Entities;
using ExperianTest.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExperianTest.ApplicationCore
{
    public class CustomerDetailsFormatter : ICustomerDetailsFormatter
    {
        public Customer Format(Customer customer)
        {
            customer.FirstName = FormatName(customer.FirstName);
            customer.LastName = FormatName(customer.LastName);

            return customer;
        }

        private string FormatName(string customerName)
        {
            string formattedName = string.Empty;

            if (string.IsNullOrEmpty(customerName) == false)
            {
                formattedName = customerName.Substring(0, 1).ToUpper();

                if (customerName.Length > 2)
                {
                    formattedName = formattedName + customerName.Substring(1);
                }
            }

            return formattedName;
        }
    }
}
