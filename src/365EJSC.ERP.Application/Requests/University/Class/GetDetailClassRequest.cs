using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.University.Class
{
    public record GetDetailClassRequest : IQuery<Domain.Entities.University.Class>
    {
        public int? Id { get; set; }
    }
}