using VulcanoTest.DTO;

namespace VulcanoTest.Services
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetProducts();
        Task<ProductDTO?> GetProductsById(string id);
        Task<ProductDTO> CreateProduct(ProductDTO productDTO);
        Task UpdateProduct(string id, ProductDTO productDTO);
        Task DeleteProduct(string id);
    }
}