using System.Linq;
using Xunit;

namespace CustomerLibrary.Tests
{
    public class CustomerValidatorTests
    {
        public CustomerValidator? validator;
        public static readonly Address[] addresses = new Address[]{
                new Address(
                    "Line",
                    Type.Shipping,
                    "City",
                    "123456",
                    "State",
                    "Canada"
                ),
                new Address(
                    "Line2",
                    Type.Billing,
                    "City2",
                    "123457",
                    "State2",
                    "United States"
                )
            };

        public static readonly string[] notes = new string[] { "Note", "Note2" };

        [Fact]
        public void ShouldValidateFieldLengths()
        {
            validator = new CustomerValidator();

            var results = validator.Validate(new Customer(
                new string('l', 50),
                new string('f', 50),
                addresses,
                notes
                ));
            Assert.True(results.IsValid);

            results = validator.Validate(new Customer(
                new string('l', 51),
                new string('f', 51),
                addresses,
                notes
                ));
            string[] expectedErrors = new string[]
            {
                "'Last Name' must be between 2 and 50 characters. You entered 51 characters.",
                "'First Name' must be between 2 and 50 characters. You entered 51 characters."
            };
            Assert.Equal(expectedErrors, results.Errors.Select(e => e.ErrorMessage).ToArray());
        }

        [Fact]
        public void ShouldAcceptValidPhone()
        {
            validator = new CustomerValidator();

            var results = validator.Validate(new Customer(
                new string('l', 50),
                new string('f', 50),
                addresses,
                notes,
                "88005553535"
                ));
            Assert.True(results.IsValid);

            results = validator.Validate(new Customer(
                new string('l', 50),
                new string('f', 50),
                addresses,
                notes,
                "Invalid phone"
                ));
            Assert.Equal("'Phone' is not in the correct format.", results.Errors[0].ErrorMessage);
        }

        [Fact]
        public void ShouldAcceptValidEmail()
        {
            validator = new CustomerValidator();

            var results = validator.Validate(new Customer(
                new string('l', 50),
                new string('f', 50),
                addresses,
                notes,
                null,
                "mail@example.com"
                ));
            Assert.True(results.IsValid);

            results = validator.Validate(new Customer(
                new string('l', 50),
                new string('f', 50),
                addresses,
                notes,
                null,
                "Invalid email"
                ));
            Assert.Equal("'Email' is not a valid email address.", results.Errors[0].ErrorMessage);
        }

        [Fact]
        public void TotalPurchasesAmountCanBeNull()
        {
            validator = new CustomerValidator();

            var results = validator.Validate(new Customer(
                new string('l', 50),
                new string('f', 50),
                addresses,
                notes,
                null,
                null,
                null
                ));
            Assert.True(results.IsValid);
        }

        [Fact]
        public void ShouldHaveOneAddress()
        {
            validator = new CustomerValidator();

            var results = validator.Validate(new Customer(
                new string('l', 50),
                new string('f', 50),
                new Address[] { },
                notes
                ));
            Assert.Equal("'Addresses' must not be empty.", results.Errors[0].ErrorMessage);
        }

        [Fact]
        public void ShouldHaveOneNote()
        {
            validator = new CustomerValidator();

            var results = validator.Validate(new Customer(
                new string('l', 50),
                new string('f', 50),
                addresses,
                new string[] { }
                ));
            Assert.Equal("'Notes' must not be empty.", results.Errors[0].ErrorMessage);
        }
    }
}
