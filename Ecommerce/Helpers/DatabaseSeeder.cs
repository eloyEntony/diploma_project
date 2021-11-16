using Ecommerce.Constants;
using Ecommerce.Data;
using Ecommerce.Data.Entities;
using Ecommerce.Data.Entities.Product;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Helpers
{
    public class DatabaseSeeder
    {
        public static void SeedData(IServiceProvider services, IWebHostEnvironment env, IConfiguration config)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var manager = scope.ServiceProvider.GetRequiredService<UserManager<UserApp>>();
                var managerRole = scope.ServiceProvider.GetRequiredService<RoleManager<RoleApp>>();
                var context = scope.ServiceProvider.GetRequiredService<ApplContext>();
                //SeedUsers(manager, managerRole);

                //SeedProduct(context);

                //CleanDatabase(context);
            }
        }
        private static void SeedUsers(UserManager<UserApp> userManager, RoleManager<RoleApp> roleManager)
        {
            var roleName = "Admin";
            if (roleManager.FindByNameAsync(roleName).Result == null)
            {
                var resultAdminRole = roleManager.CreateAsync(new RoleApp
                {
                    Name = "Admin"
                }).Result;
                var resultUserRole = roleManager.CreateAsync(new RoleApp
                {
                    Name = "User"
                }).Result;                
            }


            string email = "admin@gmail.com";
            var admin = new UserApp
            {
                Email = email,
                UserName = email
            };
            var user = new UserApp
            {
                Email = "user.user@gmail.com",
                UserName = "user.user@gmail.com"
            };

            var resultAdmin = userManager.CreateAsync(admin, "Qwerty-1").Result;
            resultAdmin = userManager.AddToRoleAsync(admin, Roles.Admin).Result;

            var resultUser = userManager.CreateAsync(user, "Qwerty-1").Result;
            resultUser = userManager.AddToRoleAsync(user, Roles.User).Result;
        }

        private static void SeedProduct(ApplContext _context)
        {

            var brands = new List<BrandEntity> { new BrandEntity { Name = "Apple" } , new BrandEntity { Name = "Baseus" }, new BrandEntity { Name = "Samsung" } };
            _context.Brands.AddRange(brands);
            _context.SaveChanges();

            var catalogs = new List<CatalogEntity> { new CatalogEntity { Name = "Смартфоны, ТВ и Электроника", Image = "phone.jpg" }, 
                                                     new CatalogEntity { Name = "Товары для дома", Image = "home.jpg" } };

            _context.Catalogs.AddRange(catalogs);
            _context.SaveChanges();

            var categories = new List<CategoryEntity> { new CategoryEntity { Name = "Мобильные телефоны", CatalogId = 1 },
                                                        new CategoryEntity { Name = "Телевизоры", CatalogId = 1 },    
                                                        new CategoryEntity { Name = "Наушники и аксессуары", CatalogId = 1 }};

            _context.Categories.AddRange(categories);
            _context.SaveChanges();





            var product = new ProductEntity { Name = "Samsung Galaxy M52", CategoryId = 1, Price = 10999, Description = "5G 6/128GB Light Blue", BrandId = 3  };

            _context.Products.Add(product);
            _context.SaveChanges();


            var products = new List<ProductEntity> { new ProductEntity { Name = "Samsung Galaxy S21", CategoryId = 1, Price = 23999, Description = "8/128GB Phantom Pink", BrandId = 3 },
                                                     new ProductEntity { Name = "Samsung Galaxy M22", CategoryId = 1, Price = 6499, Description = "4/128GB Light Blue", BrandId = 3 }};

            _context.Products.AddRange(products);
            _context.SaveChanges();






            var attributeGroups = new List<ProductAttributeGroup> { new ProductAttributeGroup { Name = "Дисплей", CategoryId = 1,  },
                                                                    new ProductAttributeGroup { Name = "Функции памяти", CategoryId = 1 },
            };

            _context.ProductAttributeGroups.AddRange(attributeGroups);
            _context.SaveChanges();



            var attribute = new List<ProductAttribute> { new ProductAttribute { Name = "Диагональ экрана", GroupId = 1, Value = "6.1" },
                                                         new ProductAttribute {Name = "Разрешение дисплея", GroupId = 1, Value = "2400 x 1080"  },
                                                         new ProductAttribute {Name = "Тип матрицы", GroupId = 1 , Value = "Super AMOLED Plus" },
                                                         new ProductAttribute {Name = "Частота обновления экрана", GroupId = 1,  Value = "120 Гц" },

                                                         new ProductAttribute {Name = "Оперативная память", GroupId = 2 , Value = "6 ГБ" },
                                                         new ProductAttribute {Name = "Встроенная память", GroupId = 2, Value = "128 ГБ"  },
                                                         new ProductAttribute {Name = "Формат поддерживаемых карт памяти", GroupId = 2, Value = "microSD"  },
            };

            _context.ProductAttributes.AddRange(attribute);
            _context.SaveChanges();



            //var productAttributeValues = new List<ProductAttributeValue> { new ProductAttributeValue { AttributeId = _context.ProductAttributes.First(x=>x.)} };

            //_context.ProductAttributeValues.AddRange(productAttributeValues);
            //_context.SaveChanges();



        }

        private static void CleanDatabase(ApplContext _context)
        {
            //_context.Categories.RemoveRange(_context.Categories);

            _context.Brands.RemoveRange(_context.Brands.ToList()) ;
            _context.SaveChanges();

        }
    }
}
