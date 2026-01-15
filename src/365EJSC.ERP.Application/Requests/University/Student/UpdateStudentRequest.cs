using _365EJSC.ERP.Contract.Abstractions;
using System.Text.Json.Serialization;

namespace _365EJSC.ERP.Application.Requests.University.Student
{
    public record UpdateStudentRequest : ICommand
    {
        [JsonIgnore]
        public int? Id { get; set; }
        public string? StudentCode { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int? ClassId { get; set; }
    }
}
