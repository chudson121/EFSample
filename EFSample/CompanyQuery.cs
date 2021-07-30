#nullable enable
using System;
using Ardalis.Specification;

namespace EFSample
{
    public sealed class CompanyQuery : Specification<Company>
    {
        public CompanyQuery(Guid id)
        {
            Query.Where(x => x.CompanyId == id);

            WithIncludes();
        }

        public CompanyQuery(string name)
        {
            Query.Where(x => x.Name.ToLowerInvariant().Contains(name.ToLowerInvariant()));

            WithIncludes();
        }

        public CompanyQuery(int skip, int take, string? direction)
        {
            if (string.Equals(direction, nameof(Constants.Direction.Asc), StringComparison.OrdinalIgnoreCase))
            {
                Query.OrderBy(x => x.Name);
            }
            if (string.Equals(direction, nameof(Constants.Direction.Desc), StringComparison.OrdinalIgnoreCase))
            {
                Query.OrderByDescending(x => x.Name);
            }

            Query
                .Skip(skip)
                .Take(take);
        }

        private void WithIncludes()
        {
            //Include additional related tables
            Query
                .Include(x => x.HeadquarterAddress)
                .Include(x => x.Links)
                ;


        }

    }
}
