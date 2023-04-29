namespace Order.Entities.Models.DTOs
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public decimal? Total { get; set; }
        public Product Product { get; set; }
    }
}
