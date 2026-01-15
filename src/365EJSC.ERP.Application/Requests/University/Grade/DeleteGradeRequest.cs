using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.University.Grade
{
    public record DeleteGradeRequest : ICommand
    {
        public int? Id { get; set; }
    }
}