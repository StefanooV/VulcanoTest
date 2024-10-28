using VulcanoTest.DTO;
using VulcanoTest.Models;

namespace VulcanoTest.Infraestructura.Mappings
{
    public static class ProductMappings
    {
          public static Product ToEntity(this ProductDTO dto)
        {
            return new Product
            {
                Name = dto.name,
                Description = dto.description,
                Price = dto.price,
                DateTime = dto.dateTime
            };
        }

        public static ProductDTO ToDTO(this Product entity)
        {
            return new ProductDTO
            {
                name = entity.Name,
                description = entity.Description,
                price = entity.Price,
                dateTime = entity.DateTime
            };
        }
    }
}