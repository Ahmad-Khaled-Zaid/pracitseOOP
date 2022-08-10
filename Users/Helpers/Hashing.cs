using System.Security.Cryptography;
using System.Text;
namespace Users.Helpers
{
    class Hashing
    {
        public static string HashPassword(string password)
        {
            var sha = SHA256.Create();
            byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            var sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
