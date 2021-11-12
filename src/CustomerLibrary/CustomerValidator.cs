using FluentValidation;

namespace CustomerLibrary
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.LastName).Length(2, 50);
            RuleFor(x => x.FirstName).Length(2, 50);
            RuleFor(x => x.Addresses).NotEmpty();
            RuleFor(x => x.Notes).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Phone).Matches(@"^\+?[1-9]\d{1,14}$");            
        }
    }
}
