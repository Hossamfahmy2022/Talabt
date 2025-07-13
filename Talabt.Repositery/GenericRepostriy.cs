using Microsoft.EntityFrameworkCore;
using Talabt.Core.Entities;
using Talabt.Core.Reposirties.Contracts;
using Talabt.Core.Specasifcations;
using Talabt.Repositery.Data;

namespace Talabt.Repositery
{
    public class GenericRepostriy<T>(ApplicationDbContext context) : IGenericRepostriy<T> where T : BaseEntity
    {
        public async Task<IEnumerable<T>> GetAllAsync() => await context.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> GetAllWithSpecsAsync(ISpecasifcations<T> specasifcations)
        {
            var querywithspec = ApplySpecifications(specasifcations);
           return await querywithspec.AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetAsync(int id) =>  await context.Set<T>().FindAsync(id);


        public async Task<T?> GetWithSpecsAsync( ISpecasifcations<T> specasifcations)
        {
            var querywithspec = ApplySpecifications(specasifcations);
            return await querywithspec.AsNoTracking().FirstOrDefaultAsync();
        }

        private IQueryable<T> ApplySpecifications(ISpecasifcations<T> specasifcations)
        {
            return SpecisificationEvalutor<T>.
                GetQuery(context.Set<T>(), specasifcations);
        }
    }

    
}
