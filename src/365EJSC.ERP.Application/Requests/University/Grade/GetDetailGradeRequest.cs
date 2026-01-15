using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.University.Grade
{
    public record GetDetailGradeRequest : IQuery<Domain.Entities.University.Grade>
    {
        public int? Id { get; set; }
    }
}