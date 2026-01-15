using _365EJSC.ERP.Contract.Abstractions;
using System.Text.Json.Serialization;

namespace _365EJSC.ERP.Application.Requests.University.User
{
    public record ChangePasswordRequest : ICommand
    {
        [JsonIgnore]
        public int? Id { get; set; }
        public string CurrentPasswordHash { get; set; }
        public string NewPasswordHash { get; set; }
    }
}