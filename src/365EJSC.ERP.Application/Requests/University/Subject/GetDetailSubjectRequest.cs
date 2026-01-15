using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.University.Subject
{
    public record GetDetailSubjectRequest : IQuery<Domain.Entities.University.Subject>
    {
        public int? Id { get; set; }
    }
}