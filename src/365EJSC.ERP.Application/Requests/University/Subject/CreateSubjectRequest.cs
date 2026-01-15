using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.University.Subject
{
    public record CreateSubjectRequest : ICommand
    {
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public int Credits { get; set; }
        public string? Description { get; set; }
        public int? PrerequisiteId { get; set; }
    }
}