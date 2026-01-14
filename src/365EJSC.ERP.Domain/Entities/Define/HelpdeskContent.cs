using _365EJSC.ERP.Domain.Abstractions.Aggregates;

namespace _365EJSC.ERP.Domain.Entities.Define
{
    public class HelpdeskContent : AggregateRoot<int>
    {
        public string ContentDetail { get; set; }
        public int CatalogId { get; set; }
        public HelpdeskCatalog Catalog { get; set; }
    }
}
