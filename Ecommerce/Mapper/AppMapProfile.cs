using AutoMapper;
using Ecommerce.Data.Entities;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Mapper
{
    public class AppMapProfile : Profile
    {
        public AppMapProfile()
        {
            CreateMap<BrandEntity, BrandVM>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description));

            CreateMap<BrandVM, BrandEntity>().ForMember(x => x.Id, opt => opt.Ignore());


            CreateMap<CatalogEntity, CatalogVM>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Categories, opt => opt.MapFrom(x => x.Categories))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name));

            CreateMap<CatalogVM, CatalogEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore());


            CreateMap<CategoryEntity, CategoryVM>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.ParentId, opt => opt.MapFrom(x => x.ParentId))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.CatalogId, opt => opt.MapFrom(x => x.CatalogId));

            CreateMap<CategoryVM, CategoryEntity>().ForMember(x => x.Id, opt => opt.Ignore());


            CreateMap<CategoryEntity, CategorySlimVM>()
               .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
               .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name));

            CreateMap<CategorySlimVM, CategoryEntity>().ForMember(x => x.Id, opt => opt.Ignore());

        }
    }
}
