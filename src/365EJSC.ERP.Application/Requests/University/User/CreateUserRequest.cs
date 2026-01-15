using _365EJSC.ERP.Contract.Abstractions;
namespace _365EJSC.ERP.Application.Requests.University.User
{
    public record CreateUserRequest : ICommand
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
    }
}