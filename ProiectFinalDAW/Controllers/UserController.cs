using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectFinalDAW.Repositories;
using ProiectFinalDAW.Models;
using ProiectFinalDAW.Models.DTOs;
using BCryptNet = BCrypt.Net.BCrypt;
using ProiectFinalDAW.Utility;

namespace ProiectFinalDAW.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserRepository userRepository;
        private IJWTutils jwtUtils;
        public UserController(IUserRepository userR, IJWTutils jwtU)
        {
            userRepository = userR;
            jwtUtils = jwtU;
        }

        [HttpGet("{username}")]
        public IActionResult GetbyUser(string username)
        {
            var user = userRepository.GetByUsername(username);
            if (user == null)
            {
                return BadRequest(new { Message = "User does not exist" });
            }
            return Ok(user);
        }

        [HttpGet]
        [Authorization(role.User,role.Admin)]
        public IActionResult GetmyUser()
        {
            var user = (User)HttpContext.Items["User"];
            if (user == null)
            {
                return BadRequest(new { Message = "User does not exist" });
            }
            return Ok(user);
        }

        [HttpGet("orders")]
        public IActionResult GetMyOrders()
        {
            var user = (User)HttpContext.Items["User"];
            if (user == null)
            {
                return BadRequest(new { Message = "User does not exist" });
            }
            var all_orders = new OrdersDTO()
            {
                Orders = new List<OrderDTO>()
            };
            var orders = userRepository.GetAllOrders(user.Username);

            foreach (var order in orders.Orders)
            {
                var orderdto = new OrderDTO()
                {
                    Products = new List<ProductDTO>(),
                    Address = order.Address,
                    Status = order.Status.ToString()
                };
                foreach (var order_detail in order.OrderDetails)
                {
                    var productdto = new ProductDTO()
                    {
                        Title = order_detail.Product.Title,
                        Price = order_detail.Product.Price
                    };
                    orderdto.Products.Add(productdto);
                }
                all_orders.Orders.Add(orderdto);
            }
            return Ok(all_orders);
        }

        [HttpGet("secret")]
        [Authorization(role.Admin)]
        public IActionResult GetmyAdmin()
        {
            var user = (User)HttpContext.Items["User"];
            if (user == null)
            {
                return BadRequest(new { Message = "User does not exist" });
            }
            return Ok(user);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO dto)
        {
            var user = userRepository.GetByUsername(dto.Username);
            if (user == null || !BCryptNet.Verify(dto.Password,user.Password))
            {
                return BadRequest(new { Message = "User does not exist or login failed" });
            }
            var token = jwtUtils.GenerateToken(user);
            return Ok(new { Token = token });
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDTO dto)
        {
            var user = userRepository.GetByUsername(dto.Username);
            if (user != null )
            {
                return BadRequest(new { Message = "User already exists!" });
            }

            var new_user = new User
            {
                Username = dto.Username,
                Password = BCryptNet.HashPassword(dto.Password),
                Role = role.User,
                Email = dto.Email,
                Phone_number = dto.Phone_number,
                First_name = dto.First_name,
                Last_name = dto.Last_name
            };
            userRepository.Create(new_user);
            var result = userRepository.Save();

            if (result)
            {
                var token = jwtUtils.GenerateToken(new_user);
                return Ok(new { Token = token });
            }
            else return BadRequest(new { message = "Err undeva lmao" });
        }

        [HttpDelete]
        public IActionResult DeletemyUser()
        {
            var user = (User)HttpContext.Items["User"];
            if (user == null)
            {
                return BadRequest(new { Message = "User does not exist" });
            }
            userRepository.Delete(user);
            var result = userRepository.Save();
            if (result) return Ok(new { message = "Delete succesful" });
            else return BadRequest(new { message = "Delete not succesful" });
        }


        [HttpPut("update")]
        public IActionResult UpdateUser(UpdateUserDTO dto)
        {
            var user = (User)HttpContext.Items["User"];
            if (user == null)
            {
                return BadRequest(new { Message = "User does not exist!" });
            }
            var update_user = userRepository.GetByUsername(user.Username);

            if (!string.IsNullOrEmpty(dto.Email))
            {
                update_user.Email = dto.Email;
            }

            if (!string.IsNullOrEmpty(dto.Phone_number))
            {
                update_user.Phone_number = dto.Phone_number;
            }

            if (!string.IsNullOrEmpty(dto.Username))
            {
                update_user.Username = dto.Username;
            }
            userRepository.Update(update_user);
            var result = userRepository.Save();
            if (result)
            {                            
                return Ok(new { message = "Userul a fost updatat" });
            }
            else
            {
                return BadRequest(new { message = "Eroare" });
            }
        }
    }
}
