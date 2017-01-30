using System.Text;

namespace Objektno
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Returns SHA-256 hashed text.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string GetHash(this System.String text)
        {
            System.Security.Cryptography.SHA256Managed crypt = new System.Security.Cryptography.SHA256Managed();
            StringBuilder hash = new StringBuilder();

            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(text), 0, Encoding.UTF8.GetByteCount(text));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
    }
}