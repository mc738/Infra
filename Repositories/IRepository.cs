using System.Collections.Generic;
using System.Threading.Tasks;
using Infra.Specifications;

namespace Infra.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> Get(ISpecification<T> specification);
        Task<IEnumerable<T>> GetCollection(ISpecification<T> specification);
        Task Add(T item);
        void Delete(T item);
    }
}