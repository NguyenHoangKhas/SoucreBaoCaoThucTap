using _365EJSC.ERP.Domain.Abstractions.Aggregates;


namespace _365EJSC.ERP.Domain.Entities.Define
{
    public class WebLocalWardsV2 : AggregateRoot<int>
    {
        public string Name { get; set; }
        public string NameEn { get; set; }
        public string FullName { get; set; }
        public string FullNameEn { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int? WardPid { get; set; }
        public string? KeyLocalization { get; set; }
        public ICollection<WebLocalWardsV2> ChildWards { get; set; } 
    }
}
