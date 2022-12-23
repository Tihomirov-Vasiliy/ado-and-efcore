namespace DomainLayer.Entities
{
    public class Purchase
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ProductCount { get; set; }
        //public int PurchaserId { get; set; }
        public Purchaser Purchaser { get; set; }
        //public int SellerId { get; set; }
        public Seller Seller { get; set; }
    }
}
