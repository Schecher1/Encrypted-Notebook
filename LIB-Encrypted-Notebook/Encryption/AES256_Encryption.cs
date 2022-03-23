using System.Security.Cryptography;

namespace LIB_Encrypted_Notebook.Encryption
{
    public class AES256_Encryption
    {
        public byte[] AES256_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes, byte[] salt)
        {
            try
            {
                byte[] encryptedBytes = null;

                using (MemoryStream ms = new MemoryStream())
                {
                    using (AesManaged AES = new AesManaged())
                    {
                        AES.KeySize = 256;
                        AES.BlockSize = 128;

                        var key = new Rfc2898DeriveBytes(passwordBytes, salt, 1000);
                        AES.Key = key.GetBytes(AES.KeySize / 8);
                        AES.IV = key.GetBytes(AES.BlockSize / 8);

                        AES.Mode = CipherMode.CBC;

                        using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                            cs.Close();
                        }
                        encryptedBytes = ms.ToArray();
                    }
                }
                return encryptedBytes;
            }
            catch { return null; }
        }
    }
}
