using System.Security.Cryptography;
using System.Text;

namespace dotnetcoreWebAPI.Helper
{
    public class Cryptography
    {
        public static string Encrypt(string text)
        {
            var encryptionKey = "0ram@1234xxxxxxxxxxtttttuuuuuiiiiio";
            var encryptionSalt = new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 };
            var textBytes = Encoding.Unicode.GetBytes(text);

            using (var encryptor = Aes.Create())
            {
                var rfc2898DeriveBytes = new Rfc2898DeriveBytes(encryptionKey, encryptionSalt);

                encryptor.Key = rfc2898DeriveBytes.GetBytes(32);
                encryptor.IV = rfc2898DeriveBytes.GetBytes(16);

                using var memoryStream = new MemoryStream();

                using (var cryptoStream = new CryptoStream(memoryStream, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(textBytes, 0, textBytes.Length);
                    cryptoStream.Close();
                }

                text = Convert.ToBase64String(memoryStream.ToArray());
            }

            return text;
        }
        public static string Decrypt(string text)
        {
            var encryptionKey = "0ram@1234xxxxxxxxxxtttttuuuuuiiiiio";
            var encryptionSalt = new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 };

            text = text.Replace(" ", "+");

            var textBytes = Convert.FromBase64String(text);

            using (var encryptor = Aes.Create())
            {
                var rfc2898DeriveBytes = new Rfc2898DeriveBytes(encryptionKey, encryptionSalt);

                encryptor.Key = rfc2898DeriveBytes.GetBytes(32);
                encryptor.IV = rfc2898DeriveBytes.GetBytes(16);

                using var memoryStream = new MemoryStream();

                using (var cryptoStream = new CryptoStream(memoryStream, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(textBytes, 0, textBytes.Length);
                    cryptoStream.Close();
                }

                text = Encoding.Unicode.GetString(memoryStream.ToArray());
            }

            return text;
        }
    }
}
