using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectFinalDAW.Repositories;
using Microsoft.AspNetCore.Mvc;
using ProiectFinalDAW.Models;
using ProiectFinalDAW.Models.DTOs;
using ProiectFinalDAW.Utility;

namespace ProiectFinalDAW.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductRepository productRepository;
        private ICategoryRepository categoryRepository;
        private IQuantityRepository quantityRepository;
        private IJWTutils jwtUtils;

        public ProductController(IQuantityRepository quantityR, IProductRepository prodR, ICategoryRepository categR, IJWTutils jwtU)
        {
            productRepository = prodR;
            categoryRepository = categR;
            quantityRepository = quantityR;
            jwtUtils = jwtU;
        }

        [HttpGet("{product}")]
        public IActionResult GetbyProduct(string product)
        {
            var prod = productRepository.GetbyProduct(product);
            
            if(prod == null )
            {
                return BadRequest(new { Message = "Product does not exist" });
            }
            var dto = new AddProductDTO
            {
                Title = prod.Title,
                Description = prod.Description,
                Price = prod.Price,
                Activate = prod.Activate,
                CategoryName = prod.Category.Name,
                QuantityName = prod.Quantity.Name,
                Cantitate = prod.Quantity.Cantitate
            };
            return Ok(dto);
        }

        [HttpPost("addproduct")]
        [Authorization(role.Admin)]
        public IActionResult AddProduct(AddProductDTO dto)
        {
            var prod = productRepository.GetbyProduct(dto.Title);
            if (prod != null)
            {
                return BadRequest(new { Message = "Product already exists" });
            }

            var categ = categoryRepository.GetByCategory(dto.CategoryName);
            if (categ == null)
            {
                categ = new Category
                {
                    Name = dto.CategoryName,
                    Description = "update later"
                };
                categoryRepository.Create(categ);
                bool result2 = categoryRepository.Save();
                if (!result2) return BadRequest(new { Message = "Lmao idk(product create new categ)" }); 
            }

            var quant = quantityRepository.GetbyName(dto.QuantityName);
            if (quant == null)
            {
                quant = new Quantity
                {
                    Name = dto.QuantityName,
                    Cantitate = dto.Cantitate
                };
                quantityRepository.Create(quant);
                bool result2 = quantityRepository.Save();
                if (!result2) return BadRequest(new { Message = "Lmao idk(product create new quant)" });
            }

            var new_product = new Product
            {
                Title = dto.Title,
                Description = dto.Description,
                Price = dto.Price,
                Activate = dto.Activate,
                CategoryId = categ.Id,
                QuantityId = quant.Id
            };

            productRepository.Create(new_product);
            var result = productRepository.Save();

            if (result) return Ok(result);
            else return BadRequest(new { message = "err undeva lmao(product controller)" });
        }
    }
}
