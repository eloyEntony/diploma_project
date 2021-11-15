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
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogService _catalogService;
        public CatalogController(ICatalogService catalogService)=> _catalogService = catalogService;


        [HttpPost("add")]
        public async Task<IActionResult> AddCatalog([FromBody] CatalogVM model)
        {            
            var result = await _catalogService.AddAsync(model);
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
                return Ok(await _catalogService.GetAllAsync()); 
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
                return Ok(await _catalogService.GetById(id));
            }
            catch (Exception)
            {
                return BadRequest("Get error");
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] CatalogVM brand)
        {

            var result = await _catalogService.UpdateAsync(brand);
            if (result.IsSuccessful)
                return Ok(result.Message);
            else
                return BadRequest("Update error");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _catalogService.Delete(id);
            if (result.IsSuccessful)
                return Ok(result.Message);
            else
                return BadRequest("Delete error");
        }
    }
}
