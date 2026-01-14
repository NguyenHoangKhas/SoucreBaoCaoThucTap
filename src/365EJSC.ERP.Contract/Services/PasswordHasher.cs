using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Contract.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        /// <summary>
        /// Using <see cref="BCrypt.Net.BCrypt"/> to hash password
        /// </summary>
        /// <param name="password">Password to hash</param>
        /// <returns>Hashed password</returns>
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        /// <summary>
        /// Using <see cref="BCrypt.Net.BCrypt"/> to verify password
        /// </summary>
        /// <param name="password">Password to verify</param>
        /// <param name="hashedPassword">Hashed password use for verify</param>
        /// <returns>True if hashed password is hashed from password, otherwise False</returns>
        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
