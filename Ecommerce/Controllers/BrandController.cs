using AutoMapper;
using Ecommerce.Data.Entities;
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
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;
        public BrandController(IBrandService brandService)=>_brandService = brandService;


        [HttpPost("add")]
        public async Task<IActionResult> AddBrand([FromBody] BrandVM model)
        {            
            var result = await _brandService.AddAsync(model);
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
                return Ok(await _brandService.GetAllAsync()); 
            }
            catch (Exception)
            {
                return BadRequest("Get error");
            }           
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try { 
                return Ok(await _brandService.GetById(id));
            }
            catch (Exception)
            {
                return BadRequest("Get error");
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] BrandVM brand)
        {

            var result = await _brandService.UpdateAsync(brand);
            if (result.IsSuccessful)
                return Ok(result.Message);
            else
                return BadRequest("Update error");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _brandService.Delete(id);
            if (result.IsSuccessful)
                return Ok(result.Message);
            else
                return BadRequest("Delete error");
        }
    }
}
