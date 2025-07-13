
namespace Talabt.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } 
        public  string Description { get; set; } 
        public decimal Price { get; set; }
        public  string PictureUrl { get; set; }

        public int BrandId { get; set; }
        public int CatergoryId { get; set; }
        public ProducrtBrand Brand { get; set; } = new ProducrtBrand();
        public ProductCatergory catergory { get; set; } = new ProductCatergory();

    }
}
