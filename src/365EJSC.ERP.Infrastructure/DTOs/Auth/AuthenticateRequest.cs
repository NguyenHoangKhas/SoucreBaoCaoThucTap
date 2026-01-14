using System.ComponentModel.DataAnnotations;

namespace _365EJSC.ERP.Infrastructure.DTOs.Auth
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
