using Talabt.Core.Entities;
using Talabt.Core.Specasifcations;

namespace Talabt.Core.Reposirties.Contracts
{
    public interface IGenericRepostriy<T> where T : BaseEntity
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<IEnumerable<T>> GetAllWithSpecsAsync(ISpecasifcations<T> specasifcations);
        public Task<T?> GetAsync(int id);
        public Task<T?> GetWithSpecsAsync(ISpecasifcations<T> specasifcations);


    }
}
