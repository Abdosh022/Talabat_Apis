using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Repository.Data
{
    public static class StoreContextSeed
    {
        public async  static Task SeedAsync(StoreContext _dbcontext)
        {
            if (_dbcontext.productBrands.Count() == 0)
            { 
                var brandsData = File.ReadAllText("../Talabat.Repository/Data/DataSeed/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                if (brands?.Count > 0)
                {
                    //brands = brands.Select(b => new ProductBrand()
                    //{
                    //    Name = b.Name,
                    //}).ToList();
                    foreach (var brand in brands)
                    {
                        _dbcontext.Set<ProductBrand>().Add(brand);
                    }
                    await _dbcontext.SaveChangesAsync();
                } 
            }
            if (_dbcontext.productCategory.Count() == 0)
            {
                var CategoriesData = File.ReadAllText("../Talabat.Repository/Data/DataSeed/categories.json");
                var Categories = JsonSerializer.Deserialize<List<ProductCategory>>(CategoriesData);

                if (Categories?.Count > 0)
                {
                    //brands = brands.Select(b => new ProductBrand()
                    //{
                    //    Name = b.Name,
                    //}).ToList();
                    foreach (var Category in Categories)
                    {
                        _dbcontext.Set<ProductCategory>().Add(Category);
                    }
                    await _dbcontext.SaveChangesAsync();
                }
            }
            if (_dbcontext.products.Count() == 0)
            {
                var productsData = File.ReadAllText("../Talabat.Repository/Data/DataSeed/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                if (products?.Count > 0)
                {
                    //brands = brands.Select(b => new ProductBrand()
                    //{
                    //    Name = b.Name,
                    //}).ToList();
                    foreach (var product in products)
                    {
                        _dbcontext.Set<Product>().Add(product);
                    }
                    await _dbcontext.SaveChangesAsync();
                }
            }

        }
    }
}

