namespace Talabt.Core.Entities
{
    public class ProductCatergory:BaseEntity
    {
        public string Name { set; get; }
        public ICollection<Product> products { set; get; } = new HashSet<Product>();
    }
}
