using _365EJSC.ERP.Contract.Abstractions;
using System.Text.Json.Serialization;

namespace _365EJSC.ERP.Application.Requests.University.Subject
{
    public record UpdateSubjectRequest : ICommand
    {
        [JsonIgnore]
        public int? Id { get; set; }
        public string? SubjectCode { get; set; }
        public string? SubjectName { get; set; }
        public int? Credits { get; set; }
        public string? Description { get; set; }
        public int? PrerequisiteId { get; set; }
    }
}