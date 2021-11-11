namespace CustomerLibrary
{
    public abstract class Person
    {
        public string? FirstName { get; set; }

        public string LastName { get; set; }

        protected Person(string lastName, string? firstName = null)
        {
            FirstName = firstName;
            LastName = lastName;
        }        
    }
}
