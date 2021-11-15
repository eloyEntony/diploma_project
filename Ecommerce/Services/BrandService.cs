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
    public interface IBrandService
    {
        Task<ResultResponse> AddAsync(BrandVM model);
        Task<ResultResponse> UpdateAsync(BrandVM model);        
        Task<IList<BrandVM>> GetAllAsync();
        Task<BrandVM> GetById(long id);
        Task<ResultResponse> Delete(long id);
    }

    public class BrandService : IBrandService
    {
        private readonly ApplContext _context;
        private readonly IMapper _mapper;
        public BrandService(ApplContext context, IMapper mapper) => (_context, _mapper) = (context, mapper);
       
        public async Task<ResultResponse> AddAsync(BrandVM model)
        {
            var brand = _mapper.Map<BrandEntity>(model);
            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();
            return new ResultResponse() { IsSuccessful = true, Message = "Brand is added" };
        }      

        public async Task<IList<BrandVM>> GetAllAsync()
        {
            var brands = await _context.Brands.ToListAsync();
            return _mapper.Map<IList<BrandEntity>, IList<BrandVM>>(brands);
        }

        public async Task<BrandVM> GetById(long id)
        {
            var brand = await _context.Brands.FirstOrDefaultAsync(x => x.Id == id);            
            return _mapper.Map<BrandEntity, BrandVM>(brand);                
        }

        public async Task<ResultResponse> UpdateAsync(BrandVM model)
        {
            var brand = await _context.Brands.FirstOrDefaultAsync(x => x.Id == model.Id);
            _mapper.Map<BrandVM, BrandEntity>(model, brand);
            _context.Brands.Update(brand);
            await _context.SaveChangesAsync();
            return new ResultResponse() { IsSuccessful = true, Message = "Brand is updated" };
        }

        public async Task<ResultResponse> Delete(long id)
        {
            var brand = await _context.Brands.FirstOrDefaultAsync(x => x.Id == id);
            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();
            return new ResultResponse() {IsSuccessful = true, Message = "Brand is delete"};
        }       
    }
}
