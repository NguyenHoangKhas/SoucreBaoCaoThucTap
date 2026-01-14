using _365EJSC.ERP.Domain.Abstractions.Aggregates;

namespace _365EJSC.ERP.Domain.Entities.Define
{
    public class HelpdeskCatalog : AggregateRoot<int>
    {
        public string KeyCatalog { get; set; }
        public string NameVn { get; set; }
        public string? Url { get; set; }
        public bool IsActived { get; set; }
        public ICollection<HelpdeskContent> Contents { get; set; } = new List<HelpdeskContent>();
    }
}
