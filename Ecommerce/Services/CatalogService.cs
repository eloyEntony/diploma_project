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
    public interface ICatalogService
    {
        Task<ResultResponse> AddAsync(CatalogVM model);
        Task<ResultResponse> UpdateAsync(CatalogVM model);
        Task<IList<CatalogVM>> GetAllAsync();
        Task<CatalogVM> GetById(long id);
        Task<ResultResponse> Delete(long id);
    }
    public class CatalogService : ICatalogService
    {
        private readonly ApplContext _context;
        private readonly IMapper _mapper;
        public CatalogService(ApplContext context, IMapper mapper) => (_context, _mapper) = (context, mapper);


        public async Task<ResultResponse> AddAsync(CatalogVM model)
        {
            var catalog = _mapper.Map<CatalogEntity>(model);
            await _context.Catalogs.AddAsync(catalog);
            await _context.SaveChangesAsync();

            return new ResultResponse() { IsSuccessful = true, Message = "Catalog is added" };
        }

        public async Task<ResultResponse> Delete(long id)
        {
            var res = await _context.Catalogs.FirstOrDefaultAsync(x=>x.Id==id);
            if (res != null)
            {
                _context.Catalogs.Remove(res);
                await _context.SaveChangesAsync();
                return new ResultResponse() { IsSuccessful = true, Message = "Catalog is delete" };
            }
            return new ResultResponse() { IsSuccessful = true, Message = "Catalog is not delete" };
        }

        public async Task<IList<CatalogVM>> GetAllAsync()
        {
            var catalogs = await _context.Catalogs.ToListAsync();
            return _mapper.Map<IList<CatalogEntity>, IList<CatalogVM>>(catalogs);
        }

        public async Task<CatalogVM> GetById(long id)
        {
            var catalog = await _context.Catalogs.Include(x=>x.Categories).FirstOrDefaultAsync(x => x.Id == id);            
            return _mapper.Map<CatalogVM>(catalog);
        }

        public async Task<ResultResponse> UpdateAsync(CatalogVM model)
        {
            var catalog = await _context.Catalogs.FirstOrDefaultAsync(x => x.Id == model.Id);
            _mapper.Map<CatalogVM, CatalogEntity>(model, catalog);
            _context.Catalogs.Update(catalog);
            await _context.SaveChangesAsync();
            return new ResultResponse() { IsSuccessful = true, Message = "Catalog is updated" };
        }
    }
}
