namespace DomainLayer.Entities
{
    public class Purchaser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CardNumber { get; set; }
        //public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
