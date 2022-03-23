using System.Security.Cryptography;
using System.Text;

namespace LIB_Encrypted_Notebook.Encryption
{
    public class EncryptionManager
    {
        readonly Random rng = new Random();
        private static AES256_Decryption decryption = new AES256_Decryption();
        private static AES256_Encryption encryption = new AES256_Encryption();


        public static byte[] GetNewSalt()
        {
            byte[] newSalt = new byte[] { (byte)rng.Next(1, 64), (byte)rng.Next(1, 64), (byte)rng.Next(1, 64), (byte)rng.Next(1, 64), (byte)rng.Next(1, 64), (byte)rng.Next(1, 64), (byte)rng.Next(1, 64), (byte)rng.Next(1, 64) };
            return newSalt;
        }

        public static string GetHash_SHA512(string input)
        {
            try
            {
                if (input == null)
                    return null;

                StringBuilder Sb = new StringBuilder();
                using (var hash = SHA512.Create())
                {
                    Encoding enc = Encoding.UTF8;
                    Byte[] result = hash.ComputeHash(enc.GetBytes(input));

                    foreach (Byte b in result)
                        Sb.Append(b.ToString("x2"));
                }
                return Sb.ToString();
            }
            catch { return null; }
        }

        public static string EncryptAES256Salt(string input, string password, byte[] salt)
        {
            try
            {
                // Get the bytes of the string
                byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                // Hash the password with SHA256
                passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

                byte[] bytesEncrypted = encryption.AES256_Encrypt(bytesToBeEncrypted, passwordBytes, salt);

                string result = Convert.ToBase64String(bytesEncrypted);

                return result;
            }
            catch { return null; }
        }
        public static string DecryptAES256Salt(string input, string password, byte[] salt)
        {
            try
            {
                // Get the bytes of the string
                byte[] bytesToBeDecrypted = Convert.FromBase64String(input);
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

                byte[] bytesDecrypted = decryption.AES256_Decrypt(bytesToBeDecrypted, passwordBytes, salt);

                string result = Encoding.UTF8.GetString(bytesDecrypted);

                return result;
            }
            catch { return null; }
        }     
    }
}
