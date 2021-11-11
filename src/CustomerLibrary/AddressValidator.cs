using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerLibrary
{
    public class AddressValidator : IValidator<Address>
    {
        static readonly Dictionary<string, int> MaxFieldLengths = new()
        {
            { "Line", 100 },
            { "Line2", 100 },
            { "City", 50 },
            { "PostalCode", 6 },
            { "State", 20 }
        };

        static readonly string[] AcceptableCountries = new string[] { "United States", "Canada" };

        public string[] Validate(Address address)
        {
            var errorList = new List<string>();            
            foreach(var propertyName in MaxFieldLengths.Keys)
            {
                string? propertyValue = (string?) address.GetType()?.GetProperty(propertyName)?.GetValue(address);
                int maxLength = MaxFieldLengths[propertyName];
                if (propertyValue != null && propertyValue.Length > maxLength)
                {
                    errorList.Add($"{propertyName} length should not exceed {maxLength}");
                }
            }
            if (!AcceptableCountries.Contains(address.Country))
            {
                errorList.Add("This country is not supported");
            }
            return errorList.ToArray();
        }
    }
}
