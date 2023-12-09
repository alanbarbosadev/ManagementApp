using ManagementApp.Application.Specifications;
using ManagementApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementApp.Infrastructure.Utils
{
    public class SpecificationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, IBaseSpecification<T> specification)
        {
            var query = inputQuery;

            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }

            if (specification.OrderByDescending != null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }

            if (specification.IsPagingEnabled)
            {
                query = query.Skip(specification.Skip).Take(specification.Take);
            }

            foreach (var include in specification.Includes)
            {
                query = query.Include(include);
            }

            //query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}
