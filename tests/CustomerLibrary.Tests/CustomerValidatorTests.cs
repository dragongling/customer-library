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

            string[] errors = validator.Validate(new Customer(
                new string('l', 50),
                new string('f', 50),
                addresses,
                notes
                ));
            Assert.True(errors.Length == 0);

            errors = validator.Validate(new Customer(
                new string('l', 51),
                new string('f', 51),
                addresses,
                notes
                ));
            string[] expectedErrors = new string[]
            {
                "LastName length should not exceed 50",
                "FirstName length should not exceed 50"
            };
            Assert.Equal(expectedErrors, errors);
        }

        [Fact]
        public void ShouldAcceptValidPhone()
        {
            validator = new CustomerValidator();

            string[] errors = validator.Validate(new Customer(
                new string('l', 50),
                new string('f', 50),
                addresses,
                notes,
                "88005553535"
                ));
            Assert.True(errors.Length == 0);

            errors = validator.Validate(new Customer(
                new string('l', 50),
                new string('f', 50),
                addresses,
                notes,
                "Invalid phone"
                ));
            string[] expectedErrors = new string[]
            {
                "Invalid phone number"
            };
            Assert.Equal(expectedErrors, errors);
        }

        [Fact]
        public void ShouldAcceptValidEmail()
        {
            validator = new CustomerValidator();

            string[] errors = validator.Validate(new Customer(
                new string('l', 50),
                new string('f', 50),
                addresses,
                notes,
                null,
                "mail@example.com"
                ));
            Assert.True(errors.Length == 0);

            errors = validator.Validate(new Customer(
                new string('l', 50),
                new string('f', 50),
                addresses,
                notes,
                null,
                "Invalid email"
                ));
            string[] expectedErrors = new string[]
            {
                "Invalid email format"
            };
            Assert.Equal(expectedErrors, errors);
        }

        [Fact]
        public void TotalPurchasesAmountCanBeNull()
        {
            validator = new CustomerValidator();

            string[] errors = validator.Validate(new Customer(
                new string('l', 50),
                new string('f', 50),
                addresses,
                notes,
                null,
                null,
                null
                ));
            Assert.True(errors.Length == 0);
        }

        [Fact]
        public void ShouldHaveOneAddress()
        {
            validator = new CustomerValidator();

            string[] errors = validator.Validate(new Customer(
                new string('l', 50),
                new string('f', 50),
                new Address[] { },
                notes
                ));
            string[] expectedErrors = new string[]
            {
                "At least one address is required"
            };
            Assert.Equal(expectedErrors, errors);
        }

        [Fact]
        public void ShouldHaveOneNote()
        {
            validator = new CustomerValidator();

            string[] errors = validator.Validate(new Customer(
                new string('l', 50),
                new string('f', 50),
                addresses,
                new string[] { }
                ));
            string[] expectedErrors = new string[]
            {
                "At least one note is required"
            };
            Assert.Equal(expectedErrors, errors);
        }
    }
}
