using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace VulcanoTest.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no debe execeder los 100 caracteres")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "La descripción del producto es obligatorio")]
        [StringLength(300, ErrorMessage = "La descripción no debe execeder los 300 caracteres")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "El precio del producto es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal Price { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}