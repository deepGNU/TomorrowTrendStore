namespace API.Services
{
    public class PasswordHashingService
    {
        private static readonly int _workFactor = 13;

        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password, _workFactor);
        }

        public static bool VerifyPassword(string candidatePassword, string passwordHash)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(candidatePassword, passwordHash);
        }
    }
}
