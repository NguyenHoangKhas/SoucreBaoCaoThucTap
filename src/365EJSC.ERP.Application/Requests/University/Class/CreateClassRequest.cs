using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.University.Class
{
    public record CreateClassRequest : ICommand
    {
        public string ClassCode { get; set; }
        public string? ClassName { get; set; }
        public string? AcademicYear { get; set; }
        public string? Department { get; set; }
        public int? AdvisorId { get; set; }
    }
}
