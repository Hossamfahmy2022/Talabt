using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabt.Core.Entities;
using Talabt.Core.Specasifcations;

namespace Talabt.Repositery
{
   internal static class SpecisificationEvalutor<TEntity> where TEntity : BaseEntity
    {

        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery , ISpecasifcations<TEntity> specasifcations)
        {
            var query = inputQuery; // _context<TEntity> 

            if (specasifcations.Criteria is not null) // a => a.name="Hossam"
                query.Where(specasifcations.Criteria);
            //if(specasifcations.Includes.Count() != 0)
            //{
            //    foreach( var include in specasifcations.Includes)
            //        query = query.Include(include);
            //}
            // can make same for loop with aggerate 
            // query is start query as seeding
            // iterate with two CurrentQuery is latest query , includeExper
            query = specasifcations.Includes.Aggregate(query, (CurrentQuery, includeExper) => CurrentQuery.Include(includeExper));
            return query;
        }
    }
}
