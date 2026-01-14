using _365EJSC.ERP.Infrastructure.DTOs;

namespace _365EJSC.ERP.Infrastructure.Abstractions
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(UsersDTOs user);

        public UsersDTOs ValidateJwtToken(string token);
    }
}
