using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.University.LecturerSubject
{
    public record GetDetailLecturerSubjectRequest : IQuery<Domain.Entities.University.LecturerSubject>
    {
        public int? Id { get; set; }
    }
}