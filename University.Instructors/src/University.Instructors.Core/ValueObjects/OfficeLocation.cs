namespace University.Instructors.Core.ValueObjects
{
    public record OfficeLocation(string Address, string City, string PostalCode)
    {
        public OfficeLocation CreateNew(string address, string postalCode, string city)
        {
            return new OfficeLocation(address, city, postalCode);
        }
    }
}