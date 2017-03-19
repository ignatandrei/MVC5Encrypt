using System.Text.RegularExpressions;

namespace MVCEncrypt
{
    static class Base64Utils
    {
        public static bool IsBase64String(this string s)
        {
            s = s.Trim();
            return (s.Length % 4 == 0) && Regex.IsMatch(s, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);

        }
    }
}
