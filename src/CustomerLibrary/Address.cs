using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLibrary
{
    public enum Type
    {
        Shipping,
        Billing
    }

    public class Address
    {
        public string Line { get; }

        public string? Line2 { get; }

        public Type Type { get; }

        public string City { get; }

        public string PostalCode { get; }

        public string State { get; }

        public string Country { get; }

        public Address(
            string line, 
            Type type, 
            string city, 
            string postalCode, 
            string state, 
            string country
            )
        {
            Line = line;
            Type = type;
            City = city;
            PostalCode = postalCode;
            State = state;
            Country = country;
        }

        public Address(
            string line, 
            string line2, 
            Type type, 
            string city, 
            string postalCode, 
            string state, 
            string country
            )
        {
            Line = line;
            Line2 = line2;
            Type = type;
            City = city;
            PostalCode = postalCode;
            State = state;
            Country = country;
        }        
    }
}
