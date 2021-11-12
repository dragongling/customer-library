using FluentValidation;
using System;
using System.Linq;

namespace CustomerLibrary
{
    public class AddressValidator : AbstractValidator<Address>
    {
        static readonly string[] AcceptableCountries = new string[] { "United States", "Canada" };

        public AddressValidator()
        {
            RuleFor(x => x.Line).Length(4, 100);
            RuleFor(x => x.Line2).Length(4, 100);
            RuleFor(x => x.City).Length(2, 50);
            RuleFor(x => x.PostalCode).Length(5, 6);
            RuleFor(x => x.State).Length(2, 20);
            RuleFor(x => x.Country).Must(c => AcceptableCountries.Contains(c)).WithMessage("This country is not supported.");
        }
    }
}
