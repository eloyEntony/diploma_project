using Ecommerce.Data.Entities;
using Ecommerce.Data.Entities.Product;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Data
{
    public class ApplContext : IdentityDbContext<UserApp, RoleApp, long, IdentityUserClaim<long>,
            UserRole, IdentityUserLogin<long>, IdentityRoleClaim<long>, IdentityUserToken<long>>
    {
        public ApplContext(DbContextOptions<ApplContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });


            


            builder.Entity<CatalogEntity>()
                .HasMany(g => g. Categories)
                .WithOne(tr => tr.Catalog).IsRequired().HasForeignKey(s => s.CatalogId);


            builder.Entity<CategoryEntity>()
                 .HasMany(x => x.Children);


            builder.Entity<CategoryEntity>()
                 .HasOne(x => x.Parent);


            //builder.Entity<ProductAttribute>().HasMany(x=>x.Values).WithOne(c=>c.)

            //builder.Entity<ProductEntity>()
            //    .HasMany<ProductAttribute>(s => s.AttributeValues)
            //    .WithMany(c => c.Products)


            builder.Entity<ProductAttributeValue>()
            .HasKey(t => new { t.AttributeId, t.ProductId });

            builder.Entity<ProductAttributeValue>()
           .HasOne(pt => pt.Product)
           .WithMany(p => p.AttributeValues)
           .HasForeignKey(pt => pt.ProductId);

            builder.Entity<ProductAttributeValue>()
                .HasOne(pt => pt.Attribute)
                .WithMany(t => t.Products)
                .HasForeignKey(pt => pt.AttributeId);


        }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<BrandEntity> Brands { get; set; }
        public DbSet<CatalogEntity> Catalogs { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<ProductAttributeGroup> ProductAttributeGroups { get; set; }
        public DbSet<ProductAttributeValue> ProductAttributeValues { get; set; }


    }
}
