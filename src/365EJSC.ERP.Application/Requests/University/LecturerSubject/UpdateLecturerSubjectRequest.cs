using _365EJSC.ERP.Contract.Abstractions;
using System.Text.Json.Serialization;

namespace _365EJSC.ERP.Application.Requests.University.LecturerSubject
{
    public record UpdateLecturerSubjectRequest : ICommand
    {
        [JsonIgnore]
        public int? Id { get; set; }
        public string? Semester { get; set; }
        public string? AcademicYear { get; set; }
    }
}