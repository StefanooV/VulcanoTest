using Microsoft.AspNetCore.Mvc;
using VulcanoTest.DTO;
using VulcanoTest.Services;

namespace VulcanoTest.Controllers
{
    /// <summary>
    /// Controlador para gestionar operaciones relacionadas con productos.
    /// </summary>
    [ApiController]
    [Route("product")]
    public class ProductApiController : ControllerBase
    {
        private readonly IProductService _productService;

        /// <summary>
        /// Inicializa un nueva instancia del controlador
        /// </summary>
        /// <param name="productService">Servicio que gestiona la lógica de negocio de productos</param>
        public ProductApiController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Obtiene todos los productos.
        /// </summary>
        /// <returns>Lista de productos</returns>
        /// <response code="200">Lista de productos obtenida con éxito</response>
        /// <response code="500">Error al obtener la lista de productos</response>
        [HttpGet("find")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var products = await _productService.GetProducts();
                return Ok(new { message = "Productos obtenidos con éxito", data = products });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener la lista de productos", details = ex.Message });
            }

        }

        /// <summary>
        /// Obtiene un producto por su ID.
        /// </summary>
        /// <param name="id">ID del producto</param>
        /// <returns>Producto con el ID especificado</returns>
        /// <response code="200">Producto buscado y obtenido con éxito</response>
        /// <response code="404">Producto no encontrado</response>
        /// <response code="500">Error al obtener el producto</response>
        [HttpGet("findById/{id:length(24)}", Name = "GetProduct")]
        public async Task<ActionResult> Get(string id)
        {
            try
            {
                var product = await _productService.GetProductsById(id);
                if (product == null)
                {
                    return NotFound(new { message = "Producto no encontrado" });
                }

                return Ok(new { message = "Producto obtenido con éxito", data = product });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener el producto", details = ex.Message });
            }
        }

        /// <summary>
        /// Crear un  nuevo producto
        /// </summary>
        /// <param name="productDTO">Objeto del producto a crear</param>
        /// <returns>El producto creado. <see cref="ActionResult"/></returns>
        /// <response code="201">Producto creado con éxito.</response>
        /// <response code="400">Datos de entrada inválidos.</response>
        /// <response code="500">Error al crear el producto.</response>
        [HttpPost("create")]
        public async Task<ActionResult> Create(ProductDTO productDTO)
        {
            try
            {
                var createProduct = await _productService.CreateProduct(productDTO);
                return Ok(new { message = "Producto creado con éxito", data = createProduct });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al crear el producto", details = ex.Message });
            }
        }

        /// <summary>
        /// Actualiza un producto existente
        /// </summary>
        /// <param name="id">ID del producto a actualizar</param>
        /// <param name="productDTO">Los datos del producto a actualizar</param>
        /// <returns>El producto actualizado <see cref="ActionResult"/></returns>
        /// <response code="200">Producto actualizado con éxito.</response>
        /// <response code="400">Datos de entrada inválidos.</response>
        /// <response code="404">Producto no encontrado.</response>
        /// <response code="500">Error al actualizar el producto.</response>
        [HttpPut("update/{id:length(24)}")]
        public async Task<ActionResult> Update(string id, ProductDTO productDTO)
        {
            try
            {
                await _productService.UpdateProduct(id, productDTO);
                var updatedProduct = await _productService.GetProductsById(id);

                return Ok(new { message = "Producto actualizado con éxito", data = updatedProduct });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al actualizar el producto", details = ex.Message });
            }
        }


        /// <summary>
        /// Elimina un producto por su ID
        /// </summary>
        /// <param name="id">ID del producto a eliminar</param>
        /// <response code="200">Producto eliminado con éxito.</response>
        /// <response code="404">Producto no encontrado.</response>
        /// <response code="500">Error al eliminar el producto.</response>
        [HttpDelete("delete/{id:length(24)}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                await _productService.DeleteProduct(id);
                return Ok(new { message = "Producto eliminado con éxito" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al borrar el producto", details = ex.Message });
            }
        }
    }
}