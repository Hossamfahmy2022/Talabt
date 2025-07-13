using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Talabt.Core.Entities;
using Talabt.Repositery.Data.Config;

namespace Talabt.Repositery.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
             
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent Validation 
            modelBuilder.ApplyConfigurationsFromAssembly(assembly: Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> products { set; get; }
        public DbSet<ProductCatergory>  Catergories { set; get; }
        public DbSet<ProducrtBrand>  Brands { set; get; }
    }
}
