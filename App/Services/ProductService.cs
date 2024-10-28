using MongoDB.Driver;
using VulcanoTest.Domain.Validation;
using VulcanoTest.DTO;
using VulcanoTest.Infraestructura.Data;
using VulcanoTest.Infraestructura.Mappings;

namespace VulcanoTest.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDTO>> GetProducts()
        {
            try
            {
                var products = await _productRepository.GetAllAsync();
                return products.Select(p => p.ToDTO()).ToList();
            }
            catch (MongoException ex)
            {
                throw new Exception("Error al buscar los productos en la base de datos", ex);
            }
        }

        public async Task<ProductDTO?> GetProductsById(string id)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(id);
                return product?.ToDTO();
            }
            catch (MongoException ex)
            {
                throw new Exception("Error al buscar el producto en la base de datos", ex);
            }

        }
        public async Task<ProductDTO> CreateProduct(ProductDTO productDTO)
        {
            try
            {
                if (!ProductValidator.IsValidProductDTO(productDTO, out var errorMessage))
                {
                    throw new ArgumentException(errorMessage);
                }

                var product = productDTO.ToEntity();
                await _productRepository.CreateAsync(product);
                return product.ToDTO();
            }
            catch (MongoException ex)
            {
                throw new Exception("Error al insertar el producto en la base de datos", ex);
            }
        }

        public async Task UpdateProduct(string id, ProductDTO productDTO)
        {
            try
            {
                if (!ProductValidator.IsValidProductDTO(productDTO, out var errorMessage))
                {
                    throw new ArgumentException(errorMessage);
                }

                var existingProduct = await _productRepository.GetByIdAsync(id);
                if (existingProduct == null)
                {
                    throw new KeyNotFoundException("Producto no encontrado");
                }

                existingProduct.Name = productDTO.name;
                existingProduct.Description = productDTO.description;
                existingProduct.Price = productDTO.price;
                existingProduct.DateTime = productDTO.dateTime;

                await _productRepository.UpdateAsync(id, existingProduct);
            }
            catch (MongoException ex)
            {
                throw new Exception("Error al actualizar el producto en la base de datos", ex);
            }
        }

        public async Task DeleteProduct(string id)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(id);
                if (product == null)
                {
                    throw new KeyNotFoundException("Producto no encontrado");
                }

                await _productRepository.DeleteAsync(id);
            }
            catch (MongoException ex)
            {
                throw new Exception("Error al borrar el producto en la base de datos", ex);
            }
        }
    }
}