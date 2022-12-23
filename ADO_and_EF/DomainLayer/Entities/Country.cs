namespace DomainLayer.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }

        public Country()
        {

        }

        public Country(string name, int code)
        {
            Name = name;
            Code = code;
        }

        public Country(int id, string name, int code) : this(name, code)
        {
            Id = id;
        }
    }
}
