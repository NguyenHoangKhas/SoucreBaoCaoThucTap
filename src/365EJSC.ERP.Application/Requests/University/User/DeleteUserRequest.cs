using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.University.User
{
    public record DeleteUserRequest : ICommand
    {
        public int? Id { get; set; }
    }
}