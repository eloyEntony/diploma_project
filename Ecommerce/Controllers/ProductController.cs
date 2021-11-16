using Ecommerce.Models;
using Ecommerce.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService) => _productService = productService;

        [HttpPost("add")]
        public async Task<IActionResult> AddProduct([FromBody] ProductVM model)
        {
            var result = await _productService.AddAsync(model);
            if (result.IsSuccessful)
                return Ok(result.Message);
            else
                return BadRequest("Add error");
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _productService.GetAllAsync());
            }
            catch (Exception)
            {
                return BadRequest("Get error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await _productService.GetById(id));
            }
            catch (Exception)
            {
                return BadRequest("Get error");
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] ProductVM brand)
        {

            var result = await _productService.UpdateAsync(brand);
            if (result.IsSuccessful)
                return Ok(result.Message);
            else
                return BadRequest("Update error");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.Delete(id);
            if (result.IsSuccessful)
                return Ok(result.Message);
            else
                return BadRequest("Delete error");
        }
    }
}
