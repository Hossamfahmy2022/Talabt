using System.Text.Json;
using Talabt.Core.Entities;

namespace Talabt.Repositery.Data
{
    public static class StoreContextSeed
    {

        public async static Task SeedAsync(ApplicationDbContext context)
        {
            if (context.Brands.Count() == 0)
            {
                var BrandsData = File.ReadAllText("../Talabt.Repositery/Data/DataSeed/brands.json");

                var brands = JsonSerializer.Deserialize<List<ProducrtBrand>>(BrandsData);
                if (brands?.Count() > 0)
                {
                    foreach (var brand in brands)
                    {

                        await context.Brands.AddAsync(brand);
                    }
                    await context.SaveChangesAsync();
                } 
            }
            // do same for ProductCatergory
            if (context.Catergories.Count() == 0)
            {
                var CatergoriesData = File.ReadAllText("../Talabt.Repositery/Data/DataSeed/Catergories.json");

                var catergories = JsonSerializer.Deserialize<List<ProductCatergory>>(CatergoriesData);
                if (catergories?.Count() > 0)
                {
                    foreach (var catergory in catergories)
                    {

                        await context.Catergories.AddAsync(catergory);
                    }
                    await context.SaveChangesAsync();
                }
            }
            // do same for Product
            if (context.products.Count() == 0)
            {
                var productsData = File.ReadAllText("../Talabt.Repositery/Data/DataSeed/products.json");

                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                if (products?.Count() > 0)
                {
                    foreach (var product in products)
                    {

                        await context.products.AddAsync(product);
                    }
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
