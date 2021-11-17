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


            CreateMap<ProductAttribute, AttributeVM>()
              .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
              .ForMember(x => x.Value, opt => opt.MapFrom(x => x.Value))
              .ForMember(x => x.GroupId, opt => opt.MapFrom(x => x.GroupId))
              .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name));

            CreateMap<AttributeVM, ProductAttribute>().ForMember(x => x.Id, opt => opt.Ignore());


          


            CreateMap<ProductAttributeGroup, AttributeGroupVM>()
              .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
              .ForMember(x => x.CategoryId, opt => opt.MapFrom(x => x.CategoryId))
              .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name));

            CreateMap<AttributeGroupVM, ProductAttributeGroup>().ForMember(x => x.Id, opt => opt.Ignore());



            CreateMap<ProductEntity, ProductVM>()
              .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
              .ForMember(x => x.CategoryId, opt => opt.MapFrom(x => x.CategoryId))
              .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
              .ForMember(x => x.Price, opt => opt.MapFrom(x => x.Price))
              .ForMember(x => x.ShortDescription, opt => opt.MapFrom(x => x.ShortDescription))
              .ForMember(x => x.Specification, opt => opt.MapFrom(x => x.Specification))
              .ForMember(x => x.BrandId, opt => opt.MapFrom(x => x.BrandId))
              .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
              .ForMember(x=>x.Attributes, opt=>opt.Ignore());


            CreateMap<ProductAttribute, AttributeSlimVM>()
            .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
            .ForMember(x => x.Value, opt => opt.MapFrom(x => x.Value))
            .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name));
            CreateMap<AttributeSlimVM, ProductAttribute>().ForMember(x => x.Id, opt => opt.Ignore());


            CreateMap<ProductVM, ProductEntity>().ForMember(x => x.Id, opt => opt.Ignore())
                ;

        }
    }
}
