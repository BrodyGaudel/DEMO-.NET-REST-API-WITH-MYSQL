using System.ComponentModel.DataAnnotations.Schema;

namespace product_service.Entity
{
    [Table("products")]
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime DateOfManufacture { get; set; }
        // Clé étrangère
        public Guid CategoryId { get; set; }

        public Product()
        {

        }

        public Product(Guid id, string name, string description, decimal price, int quantity, DateTime dateOfManufacture, Guid categoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
            DateOfManufacture = dateOfManufacture;
            CategoryId = categoryId;
        }
    }
}
