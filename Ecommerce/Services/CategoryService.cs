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
    public interface ICategoryService
    {
        Task<ResultResponse> AddAsync(CategoryVM model);
        Task<ResultResponse> UpdateAsync(CategoryVM model);
        Task<IList<CategoryVM>> GetAllAsync();
        Task<CategoryVM> GetById(long id);
        Task<ResultResponse> Delete(long id);
    }

    public class CategoryService : ICategoryService
    {
        private readonly ApplContext _context;
        private readonly IMapper _mapper;
        public CategoryService(ApplContext context, IMapper mapper) => (_context, _mapper) = (context, mapper);
        public async Task<ResultResponse> AddAsync(CategoryVM model)
        {
            var category = _mapper.Map<CategoryEntity>(model);
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return new ResultResponse() { IsSuccessful = true, Message = "Category is added" };
        }

        public async Task<ResultResponse> Delete(long id)
        {
            var res = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (res != null)
            {
                _context.Categories.Remove(res);
                await _context.SaveChangesAsync();
                return new ResultResponse() { IsSuccessful = true, Message = "Category is delete" };
            }
            return new ResultResponse() { IsSuccessful = true, Message = "Category is not delete" };
        }

        public async Task<IList<CategoryVM>> GetAllAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            return _mapper.Map<IList<CategoryEntity>, IList<CategoryVM>>(categories);
        }

        public async Task<CategoryVM> GetById(long id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<CategoryVM>(category);
        }

        public async Task<ResultResponse> UpdateAsync(CategoryVM model)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == model.Id);
            _mapper.Map<CategoryVM, CategoryEntity>(model, category);
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return new ResultResponse() { IsSuccessful = true, Message = "Category is updated" };
        }
    }
}
