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
    public class AttributeController : ControllerBase
    {
        private readonly IAttributeService _attributeService;

        public AttributeController(IAttributeService attributeService) => _attributeService = attributeService;

        [HttpPost("add-attribute")]
        public async Task<IActionResult> AddAttribute([FromBody] AttributeVM model)
        {
            var result = await _attributeService.AddAttributeAsync(model);
            if (result.IsSuccessful)
                return Ok(result.Message);
            else
                return BadRequest("Add error");
        }
        [HttpPost("add-attribute-group")]
        public async Task<IActionResult> AddAttributeGroup([FromBody] AttributeGroupVM model)
        {
            var result = await _attributeService.AddAttributeGroupAsync(model);
            if (result.IsSuccessful)
                return Ok(result.Message);
            else
                return BadRequest("Add error");
        }


        [HttpGet("getall-attribute")]
        public async Task<IActionResult> GetAllAttribute()
        {
            try
            {
                return Ok(await _attributeService.GetAllAttributesAsync());
            }
            catch (Exception)
            {
                return BadRequest("Get error");
            }
        }

        [HttpGet("getall-attribute-group")]
        public async Task<IActionResult> GetAllAttributeGroups()
        {
            try
            {
                return Ok(await _attributeService.GetAllAttributGroupsAsync());
            }
            catch (Exception)
            {
                return BadRequest("Get error");
            }
        }


        [HttpGet("attribute/{id}")]
        public async Task<IActionResult> GetAttributeById(int id)
        {
            try
            {
                return Ok(await _attributeService.GetAttributeById(id));
            }
            catch (Exception)
            {
                return BadRequest("Get error");
            }
        }

        [HttpGet("attribute-group/{id}")]
        public async Task<IActionResult> GetAttributeGroupById(int id)
        {
            try
            {
                return Ok(await _attributeService.GetAttributeGroupById(id));
            }
            catch (Exception)
            {
                return BadRequest("Get error");
            }
        }

        [HttpPut("update-attribute")]
        public async Task<IActionResult> UpdateAttribute([FromBody] AttributeVM attribute)
        {

            var result = await _attributeService.UpdateAttributeAsync(attribute);
            if (result.IsSuccessful)
                return Ok(result.Message);
            else
                return BadRequest("Update error");

        }
        [HttpPut("update-attribute-group")]
        public async Task<IActionResult> UpdateAttributeGroup([FromBody] AttributeGroupVM attributeGroup)
        {

            var result = await _attributeService.UpdateAttributeGroupAsync(attributeGroup);
            if (result.IsSuccessful)
                return Ok(result.Message);
            else
                return BadRequest("Update error");

        }



    }
}
