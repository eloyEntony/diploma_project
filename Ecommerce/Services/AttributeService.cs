using AutoMapper;
using Ecommerce.Data;
using Ecommerce.Data.Entities;
using Ecommerce.Models;
using Ecommerce.Models.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Services
{
    public interface IAttributeService
    {
        Task<ResultResponse> AddAttributeAsync(AttributeVM model);
        Task<ResultResponse> AddAttributeGroupAsync(AttributeGroupVM model);
        Task<ResultResponse> UpdateAttributeAsync(AttributeVM model);
        Task<ResultResponse> UpdateAttributeGroupAsync(AttributeGroupVM model);

        Task<IList<AttributeVM>> GetAllAttributesAsync();
        Task<IList<AttributeGroupVM>> GetAllAttributGroupsAsync();

        Task<AttributeGroupVM> GetAttributeGroupById(long id);
        Task<AttributeVM> GetAttributeById(long id);

        //Task<ResultResponse> Delete(long id);


    }

    public class AttributeService : IAttributeService
    {
        private readonly ApplContext _context;
        private readonly IMapper _mapper;
        public AttributeService(ApplContext context, IMapper mapper) => (_context, _mapper) = (context, mapper);


        public async Task<ResultResponse> AddAttributeAsync(AttributeVM model)
        {
            var attribute = _mapper.Map<ProductAttribute>(model);
            await _context.ProductAttributes.AddAsync(attribute);
            await _context.SaveChangesAsync();
            return new ResultResponse() { IsSuccessful = true, Message = "Attribute is added" };
        }

        public async Task<ResultResponse> AddAttributeGroupAsync(AttributeGroupVM model)
        {
            var attributeGroup = _mapper.Map<ProductAttributeGroup>(model);
            await _context.ProductAttributeGroups.AddAsync(attributeGroup);
            await _context.SaveChangesAsync();
            return new ResultResponse() { IsSuccessful = true, Message = "Attribute group is added" };
        }

        public async Task<IList<AttributeVM>> GetAllAttributesAsync()
        {
            var attributes = await _context.ProductAttributes.ToListAsync();
            return _mapper.Map<IList<ProductAttribute>, IList<AttributeVM>>(attributes);
        }

        public async Task<IList<AttributeGroupVM>> GetAllAttributGroupsAsync()
        {
            var attributGroups = await _context.ProductAttributeGroups.ToListAsync();
            return _mapper.Map<IList<ProductAttributeGroup>, IList<AttributeGroupVM>>(attributGroups);
        }

        public async Task<AttributeVM> GetAttributeById(long id)
        {
            var attribute = await _context.ProductAttributes.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<ProductAttribute, AttributeVM>(attribute);
        }

        public async Task<AttributeGroupVM> GetAttributeGroupById(long id)
        {
            var attributeGroup = await _context.ProductAttributeGroups.Include(x=>x.Attributes).FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<ProductAttributeGroup, AttributeGroupVM>(attributeGroup);
        }

        public async Task<ResultResponse> UpdateAttributeAsync(AttributeVM model)
        {
            var attribute = await _context.ProductAttributes.FirstOrDefaultAsync(x => x.Id == model.Id);
            _mapper.Map<AttributeVM, ProductAttribute>(model, attribute);
            _context.ProductAttributes.Update(attribute);
            await _context.SaveChangesAsync();
            return new ResultResponse() { IsSuccessful = true, Message = "Attribute is updated" };
        }

        public async Task<ResultResponse> UpdateAttributeGroupAsync(AttributeGroupVM model)
        {
            var attributeGroup = await _context.ProductAttributeGroups.FirstOrDefaultAsync(x => x.Id == model.Id);
            _mapper.Map<AttributeGroupVM, ProductAttributeGroup>(model, attributeGroup);
            _context.ProductAttributeGroups.Update(attributeGroup);
            await _context.SaveChangesAsync();
            return new ResultResponse() { IsSuccessful = true, Message = "Attribute group is updated" };
        }
    }
}
