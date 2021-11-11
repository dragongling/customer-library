using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLibrary
{
    public class Customer : Person
    {
        public List<Address> Addresses { get; }
        public List<string> Notes { get; }
        public string? Phone { get; }
        public string? Email { get; }
        public decimal? TotalPurchasesAmount { get; }

        public Customer(
            string lastName, 
            string? firstName, 
            ICollection<Address> addresses, 
            ICollection<string> notes, 
            string? phone = null, 
            string? email = null,
            decimal? totalPurchasesAmount = null
            ) : base(lastName, firstName)
        {
            Addresses = addresses.ToList();
            Phone = phone;
            Email = email;
            Notes = notes.ToList();
            TotalPurchasesAmount = totalPurchasesAmount;
        }

        public Customer(
            string lastName,
            ICollection<Address> addresses,
            ICollection<string> notes,
            string? phone = null,
            string? email = null,
            decimal? totalPurchasesAmount = null
            ) : this(lastName, null, addresses, notes, phone, email, totalPurchasesAmount)
        {
        }
    }
}
