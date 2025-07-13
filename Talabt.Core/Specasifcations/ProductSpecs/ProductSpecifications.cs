using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabt.Core.Entities;

namespace Talabt.Core.Specasifcations.ProductSpecs
{
    public class ProductSpecifications :BaseSpecasifcation<Product>
    {
        public ProductSpecifications()
        {
            Includes.Add( p => p.Brand);
            Includes.Add(P => P.catergory);
        }

        public ProductSpecifications(int id):base(Criteria: p => p.Id==id) 
        {
            Includes.Add(p => p.Brand);
            Includes.Add(P => P.catergory);
        }
    }
}
