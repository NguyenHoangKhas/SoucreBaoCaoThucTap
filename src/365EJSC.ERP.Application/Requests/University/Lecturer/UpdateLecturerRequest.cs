using _365EJSC.ERP.Contract.Abstractions;
using System.Text.Json.Serialization;

namespace _365EJSC.ERP.Application.Requests.University.Lecturer
{
    public record UpdateLecturerRequest : ICommand
    {
        [JsonIgnore]
        public int? Id { get; set; }
        public string? LecturerCode { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Degree { get; set; }
    }
}