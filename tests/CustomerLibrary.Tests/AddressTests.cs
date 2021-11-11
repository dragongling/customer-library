using Xunit;

namespace CustomerLibrary.Tests
{
    public class AddressTests
    {
        [Fact]
        public void ShouldCreateAddress()
        {
            const string line = "Line";
            const string line2 = "Line2";
            const string city = "City";
            const string postalCode = "123456";
            const string state = "State";
            const string country = "Country";

            // Required fields only
            var address = new Address(
                line,
                Type.Shipping,
                city,
                postalCode,
                state,
                country
                );

            Assert.Equal(line, address.Line);
            Assert.Equal(Type.Shipping, address.Type);
            Assert.Equal(city, address.City);
            Assert.Equal(postalCode, address.PostalCode);
            Assert.Equal(state, address.State);
            Assert.Equal(country, address.Country);

            // All fields
            var address2 = new Address(
                line,
                line2,
                Type.Shipping,
                city,
                postalCode,
                state,
                country
                );

            Assert.Equal(line, address2.Line);
            Assert.Equal(line2, address2.Line2);
            Assert.Equal(Type.Shipping, address2.Type);
            Assert.Equal(city, address2.City);
            Assert.Equal(postalCode, address2.PostalCode);
            Assert.Equal(state, address2.State);
            Assert.Equal(country, address2.Country);
        }
    }
}
