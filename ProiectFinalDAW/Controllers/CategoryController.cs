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
    public class CategoryController : ControllerBase
    {
        private ICategoryRepository categoryRepository;
        private IJWTutils jwtUtils;

        public CategoryController(ICategoryRepository categR, IJWTutils jwtU)
        {
            categoryRepository = categR;
            jwtUtils = jwtU;
        }

        [HttpGet("{category}")]
        public IActionResult GetbyCategory (string category)
        {
            var categ = categoryRepository.GetByCategory(category);
            if(categ == null)
            {
                return BadRequest(new { Message = "Category does not exist" });
            }
            return Ok(categ);
        }

        [HttpPost("addcategory")]
        [Authorization(role.Admin)]
        public IActionResult AddCategory(AddCategoryDTO dto)
        {
            var categ = categoryRepository.GetByCategory(dto.Name);
            if (categ != null)
            {
                return BadRequest(new { Message = "Category already exists!" });
            }

            var new_categ = new Category
            {
                Name = dto.Name,
                Description = dto.Description
            };
            categoryRepository.Create(new_categ);
            var result = categoryRepository.Save();

            if (result)
            {
                return Ok(result);
            }
            else return BadRequest(new { message = "Err undeva lmao!(category controller))" });
        }
    }
}
