using Xunit;

namespace CustomerLibrary.Tests
{
    public class CustomerTests
    {
        [Fact]
        public void ShouldCreateCustomer()
        {

            var addresses = new Address[]{ 
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

            const string lastName = "LastName";
            string[] notes = new string[] { "Note", "Note2" };

            // Required fields only
            var customer = new Customer(
                lastName,
                addresses,
                notes
            );

            Assert.Equal(lastName, customer.LastName);
            Assert.Equal(addresses, customer.Addresses);
            Assert.Equal(notes, customer.Notes);

            const string firstName = "FirstName";
            const string phone = "8(800)555-35-35";
            const string email = "mail@example.com";
            const decimal totalPurchasesAmount = 12.34M;

            // All fields
            customer = new Customer(
                lastName,
                firstName,
                addresses,
                notes,
                phone,
                email,                
                totalPurchasesAmount
                );

            Assert.Equal(lastName, customer.LastName);
            Assert.Equal(firstName, customer.FirstName);
            Assert.Equal(addresses, customer.Addresses);
            Assert.Equal(notes, customer.Notes);
            Assert.Equal(phone, customer.Phone);
            Assert.Equal(email, customer.Email);
            Assert.Equal(totalPurchasesAmount, customer.TotalPurchasesAmount);
        }
    }
}
