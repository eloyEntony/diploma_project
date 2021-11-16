using AutoMapper;
using Ecommerce.Data;
using Ecommerce.Data.Entities;
using Ecommerce.Data.Entities.Product;
using Ecommerce.Models;
using Ecommerce.Models.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Services
{
    public interface IProductService
    {
        Task<ResultResponse> AddAsync(ProductVM model);
        Task<ResultResponse> UpdateAsync(ProductVM model);
        Task<IList<ProductVM>> GetAllAsync();
        Task<ProductVM> GetById(long id);
        Task<ResultResponse> Delete(long id);
    }

    public class ProductService : IProductService
    {
        private readonly ApplContext _context;
        private readonly IMapper _mapper;
        public ProductService(ApplContext context, IMapper mapper) => (_context, _mapper) = (context, mapper);

        public async Task<ResultResponse> AddAsync(ProductVM model)
        {
            var product = _mapper.Map<ProductEntity>(model);
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            var tmp = _context.Products.First(x=>x.Name == model.Name);

            foreach (var item in model.Attributes)
            {
                _context.ProductAttributeValues.Add(new ProductAttributeValue() { AttributeId = item.Id, ProductId = tmp.Id });
                _context.SaveChanges();
            }
            foreach (var item in product.AttributeValues)
            {
                //var attribut = _context.ProductAttributes.FirstOrDefault(x => x.Id == item.AttributeId);

                _context.ProductAttributeValues.Add(new ProductAttributeValue() { AttributeId = item.AttributeId, ProductId = product.Id });
            }

            return new ResultResponse() { IsSuccessful = true, Message = "Product is added" };
        }

        public async Task<ResultResponse> Delete(long id)
        {
            var res = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (res != null)
            {
                _context.Products.Remove(res);
                await _context.SaveChangesAsync();
                return new ResultResponse() { IsSuccessful = true, Message = "Product is delete" };
            }
            return new ResultResponse() { IsSuccessful = true, Message = "Product is not delete" };
        }

        public async Task<IList<ProductVM>> GetAllAsync()
        {
            var products = await _context.Products.ToListAsync();
            return _mapper.Map<IList<ProductEntity>, IList<ProductVM>>(products);
        }

        public async Task<ProductVM> GetById(long id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<ProductVM>(product);
        }

        public async Task<ResultResponse> UpdateAsync(ProductVM model)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == model.Id);
            _mapper.Map<ProductVM, ProductEntity>(model, product);
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return new ResultResponse() { IsSuccessful = true, Message = "Product is updated" };
        }
    }
}
