using product_service.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace product_service.Entity
{
    [Table("categories")]
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ProductType Type { get; set; }

        public Category(Guid id, string name, string description, ProductType type)
        {
            Id = id;
            Name = name;
            Description = description;
            Type = type;
        }

        public Category() { }
    }
}
