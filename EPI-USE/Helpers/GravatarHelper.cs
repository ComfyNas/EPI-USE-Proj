using System.Security.Cryptography;
using System.Text;

namespace EPI_USE.Helpers
{
    public static class GravatarHelper
    {
        public static string GetGravatarUrl(string email, int size = 100)
        {
            // Use MD5 hash for email address
            using (var md5 = MD5.Create())
            {
                var emailBytes = Encoding.UTF8.GetBytes(email.Trim().ToLower());
                var hashBytes = md5.ComputeHash(emailBytes);
                var hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

                // Generate Gravatar URL
                return $"https://www.gravatar.com/avatar/{hash}?s={size}&d=identicon";
            }
        }
    }
}
