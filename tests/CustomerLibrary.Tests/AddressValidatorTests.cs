using Xunit;

namespace CustomerLibrary.Tests
{
    public class AddressValidatorTests
    {
        [Fact]
        public void ShouldValidateFieldLengths()
        {
            var validator = new AddressValidator();
            string[] errors = validator.Validate(new Address(
                new string('l', 100),
                new string('l', 100),
                Type.Billing,
                new string('c', 50),
                "123456",
                new string('c', 20),
                "United States"
                ));
            Assert.True(errors.Length == 0);

            errors = validator.Validate(new Address(
                new string('l', 101),
                new string('l', 101),
                Type.Shipping,
                new string('c', 51),
                "7777777",
                new string('s', 21),
                "Kazakhstan"
                ));

            string[] expectedErrors = new string[]
            {
                "Line length should not exceed 100",
                "Line2 length should not exceed 100",
                "City length should not exceed 50",
                "PostalCode length should not exceed 6",
                "State length should not exceed 20",
                "This country is not supported"
            };

            Assert.Equal(expectedErrors, errors);
        }
    }
}
