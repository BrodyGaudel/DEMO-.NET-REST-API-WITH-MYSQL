namespace product_service.Dto
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime DateOfManufacture { get; set; }
        public Guid CategoryId { get; set; }
    }
}
