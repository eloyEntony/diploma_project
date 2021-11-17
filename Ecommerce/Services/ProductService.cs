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

            var tmpid = _context.Products.Max(x=>x.Id); // get last added item
            var tmp = _context.Products.Find(tmpid);

            foreach (var item in model.Attributes)
            {
                var a = _context.ProductAttributes.FirstOrDefault(x => x.Id == item.Id);
                var res = _context.ProductAttributeValues.Add(new ProductAttributeValue() { Attribute = a, Product = tmp });
                _context.SaveChanges();

                tmp.AttributeValues.Add(res.Entity);

                _context.SaveChanges();
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
            var products = await _context.Products.Include(x => x.AttributeValues).ToListAsync();
            return _mapper.Map<IList<ProductEntity>, IList<ProductVM>>(products);
        }

        public async Task<ProductVM> GetById(long id)
        {
            var product = await _context.Products.Include(x=>x.AttributeValues).FirstOrDefaultAsync(x => x.Id == id);
            
            var vm = _mapper.Map<ProductEntity, ProductVM>(product);

            var t = _context.ProductAttributeValues.Include(x=>x.Attribute).Where(x => x.ProductId == product.Id).ToList();
            vm.Attributes = new List<AttributeSlimVM>();
            foreach (var item in t)
            {
                var x = item.Attribute;
                var y = _mapper.Map<AttributeSlimVM>(x);
                vm.Attributes.Add(y);
            }
            return vm;
        }

        public async Task<ResultResponse> UpdateAsync(ProductVM model)
        {
            var product = await _context.Products.Include(x=>x.AttributeValues).FirstOrDefaultAsync(x => x.Id == model.Id);
            _mapper.Map<ProductVM, ProductEntity>(model, product);

            var productAttributeList = _context.ProductAttributeValues.ToList();
            int i = 0;
            foreach (var item in model.Attributes)
            {
                var a = _context.ProductAttributes.FirstOrDefault(x => x.Id == item.Id);

                var tmp = new ProductAttributeValue() { Attribute = a, Product = product, ProductId= product.Id, AttributeId= a.Id };

                //if (!productAttributeList.Contains(tmp))                
                //    continue;
                
                if ((product.AttributeValues[i].ProductId == tmp.ProductId) &&(product.AttributeValues[i].AttributeId == tmp.AttributeId))
                    continue;

                i++;
                var res = _context.ProductAttributeValues.Add(tmp);
                _context.SaveChanges();
                product.AttributeValues.Add(res.Entity);

            }

            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return new ResultResponse() { IsSuccessful = true, Message = "Product is updated" };
        }
    }
}
