namespace Order.Entities.Models.DTOs
{
    public class OrderDTO
    {
        public Guid OrderId { get; set; }
        public DateTime DateCreated { get; set; }
        public decimal Total { get; set; }
        public List<Product> Products { get; set; }
    }
}
