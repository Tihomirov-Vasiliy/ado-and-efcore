namespace DomainLayer.Entities
{
    public class Seller
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        //public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
