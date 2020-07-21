using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infra.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class SQLServerRepository<T> where T : BaseEntity
    {
        private readonly DbSet<T> set;

        public SQLServerRepository(DbSet<T> set)
        {
            this.set = set;
        }

        public async Task<T> Get(ISpecification<T> specification)
        {
            return await SpecificationEvaluator<T>.GetQuery(set, specification).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetCollection(ISpecification<T> specification)
        {
            return await GetQuery(specification).ToListAsync();
        }

        public async Task Add(T item)
        {
            await set.AddAsync(item);
        }

        private IQueryable<T> GetQuery(ISpecification<T> specification)
        {
            var query = set;

            // modify the IQueryable using the specification's criteria expression
            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            // Includes all expression-based includes
            query = specification.Includes.Aggregate(query,
                (current, include) => current.Include(include));

            // Include any string-based include statements
            query = specification.IncludeStrings.Aggregate(query,
                (current, include) => current.Include(include));

            // Apply ordering if expressions are set
            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }
            else if (specification.OrderByDescending != null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }

            if (specification.GroupBy != null)
            {
                query = query.GroupBy(specification.GroupBy).SelectMany(x => x);
            }

            // Apply paging if enabled
            if (specification.IsPagingEnabled)
            {
                query = query.Skip(specification.Skip)
                    .Take(specification.Take);
            }
            return query;
        }
    }
}