using System.Linq;
using Xunit;

namespace CustomerLibrary.Tests
{
    public class AddressValidatorTests
    {
        [Fact]
        public void ShouldValidateFieldLengths()
        {
            var validator = new AddressValidator();
            var results = validator.Validate(new Address(
                new string('l', 100),
                new string('l', 100),
                Type.Billing,
                new string('c', 50),
                "123456",
                new string('c', 20),
                "United States"
                ));

            Assert.True(results.IsValid);

            results = validator.Validate(new Address(
                new string('l', 101),
                new string('l', 101),
                Type.Shipping,
                new string('c', 51),
                "7777777",
                new string('s', 21),
                "Canada"
                ));

            string[] errors = results.Errors.Select(e => e.ErrorMessage).ToArray();
            string[] expectedErrors = new string[]
            {
                "'Line' must be between 4 and 100 characters. You entered 101 characters.",
                "'Line2' must be between 4 and 100 characters. You entered 101 characters.",
                "'City' must be between 2 and 50 characters. You entered 51 characters.",
                "'Postal Code' must be between 5 and 6 characters. You entered 7 characters.",
                "'State' must be between 2 and 20 characters. You entered 21 characters."
            };

            Assert.Equal(expectedErrors, errors);
        }

        [Fact]
        public void ShouldValidateCountry()
        {
            var validator = new AddressValidator();
            var results = validator.Validate(new Address(
                new string('l', 100),
                new string('l', 100),
                Type.Billing,
                new string('c', 50),
                "123456",
                new string('c', 20),
                "United States"
                ));
            Assert.True(results.IsValid);

            results = validator.Validate(new Address(
                new string('l', 100),
                new string('l', 100),
                Type.Billing,
                new string('c', 50),
                "123456",
                new string('c', 20),
                "Kazakhstan"
                ));

            Assert.Single(results.Errors);
            Assert.Equal("This country is not supported.", results.Errors[0].ErrorMessage);
        }
    }
}
