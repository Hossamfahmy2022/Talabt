using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabt.Core.Entities;

namespace Talabt.Core.Specasifcations
{
   public interface ISpecasifcations<T>  where T : BaseEntity 
    {
        // where  x => x.name =="hossam"  x is input as entity (T)
        public Expression<Func<T,bool>> Criteria { get; set; }

        // include x.include(y) x is entity , y is another entity
        public List<Expression<Func<T,Object>>> Includes { get; set; }
    }
}
