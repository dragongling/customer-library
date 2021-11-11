using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CustomerLibrary
{
    public class CustomerValidator : IValidator<Customer>
    {
        static readonly Dictionary<string, int> MaxFieldLengths = new()
        {
            { "LastName", 50 },
            { "FirstName", 50 }
        };

        public string[] Validate(Customer customer)
        {
            var errorList = new List<string>();
            foreach (var propertyName in MaxFieldLengths.Keys)
            {
                string? propertyValue = (string?)customer.GetType()?.GetProperty(propertyName)?.GetValue(customer);
                int maxLength = MaxFieldLengths[propertyName];
                if (propertyValue != null && propertyValue.Length > maxLength)
                {
                    errorList.Add($"{propertyName} length should not exceed {maxLength}");
                }
            }
            if (customer.Email != null && !Regex.IsMatch(customer.Email, @".+@.+\..+")){
                errorList.Add("Invalid email format");
            }
            if (customer.Phone != null && !Regex.IsMatch(customer.Phone, @"^\+?[1-9]\d{1,14}$")){
                errorList.Add("Invalid phone number");
            }
            if(customer.Addresses.Count == 0)
            {
                errorList.Add("At least one address is required");
            }
            if(customer.Notes.Count == 0)
            {
                errorList.Add("At least one note is required");
            }
            return errorList.ToArray();
        }
    }
}
