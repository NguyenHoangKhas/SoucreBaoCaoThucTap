using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.University.User
{
    public record GetDetailUserRequest : IQuery<Domain.Entities.University.User>
    {
        public int? Id { get; set; }
    }
}