using _365EJSC.ERP.Contract.Abstractions;
using System.Text.Json.Serialization;

namespace _365EJSC.ERP.Application.Requests.University.Class
{
    public record UpdateClassRequest : ICommand
    {
        [JsonIgnore]
        public int? Id { get; set; }
        public string? ClassCode { get; set; }
        public string? ClassName { get; set; }
        public string? AcademicYear { get; set; }
        public string? Department { get; set; }
        public int? AdvisorId { get; set; }
    }
}