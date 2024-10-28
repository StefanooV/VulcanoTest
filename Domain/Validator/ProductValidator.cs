using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VulcanoTest.DTO;
using VulcanoTest.Models;

namespace VulcanoTest.Domain.Validation
{
    public class ProductValidator
    {
        public static bool IsValidProduct(Product product, out string? errorMessage)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
            {
                errorMessage = "El nombre del producto no puede estar vacío";
                return false;
            }

            if (product.Price <= 0)
            {
                errorMessage = "El precio del producto debe ser mayor a 0";
                return false;
            }

            errorMessage = null;
            return true;
        }

        public static bool IsValidProductDTO(ProductDTO productDTO, out string? errorMessage)
        {
            if (string.IsNullOrWhiteSpace(productDTO.name))
            {
                errorMessage = "El nombre del producto no puede estar vacío";
                return false;
            }

            if (productDTO.price <= 0)
            {
                errorMessage = "El precio del producto debe ser mayor a 0";
                return false;
            }

            errorMessage = null;
            return true;
        }
    }
}