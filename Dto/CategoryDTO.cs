using product_service.Enums;

namespace product_service.Dto
{
    public class CategoryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ProductType Type { get; set; }

        public CategoryDTO() { }

        public CategoryDTO(Guid id, string name, string description, ProductType type)
        {
            Id = id;
            Name = name;
            Description = description;
            Type = type;
        }
    }
}
