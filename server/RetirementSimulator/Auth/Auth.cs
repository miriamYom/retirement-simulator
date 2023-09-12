using BCrypt.Net;
namespace BL.BLImplements
{
    public class Auth
    {
        public static string HashPassword(string password)
        {   // Generate a new salt and hash the password   
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);
            return hashedPassword;
        }
        public static bool VerifyPassword(string password, string hashedPassword)
        {        // Verify the password against the hashed password   
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

    }
}
