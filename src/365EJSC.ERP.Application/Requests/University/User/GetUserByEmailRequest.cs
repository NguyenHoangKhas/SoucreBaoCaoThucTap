using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.University.User
{
    public record GetUserByEmailRequest : IQuery<Domain.Entities.University.User>
    {
        public string Email { get; set; }
    }
}