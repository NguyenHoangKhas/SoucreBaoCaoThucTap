using _365EJSC.ERP.Contract.DependencyInjection.Extensions;
using _365EJSC.ERP.Contract.Shared;

namespace _365EJSC.ERP.Contract.Helpers
{
    public static class PaginationHelper
    {
        public static object ApplyPaginationSkipTake<T>(IQueryable<T> data, PaginationOptionalQuery query) where T : class
            => query.PageNumber > 0 ? ApplyPaging(data, query.MapTo<PaginationQuery>()!) : ApplySkipTake(data, query);

        public static IQueryable<T> ApplySkipTake<T>(IQueryable<T> data, SkipTakeQuery query) where T : class
        {
            // Apply skip items.
            data = data.Skip(query.Skip ?? 0);

            // Apply take items.
            if (query.Take.HasValue) return data.Take(query.Take.Value);

            return data;
        }

        public static PagedList<T> ApplyPaging<T>(IQueryable<T> data, PaginationQuery query) where T : class
        {
            var totalItems = data.Count();

            //Pagination
            var items = data.Skip((query.PageNumber - 1) * query.PageSize).Take(query.PageSize);

            return new PagedList<T>(items, totalItems, query.PageNumber, query.PageSize);
        }
    }
}
