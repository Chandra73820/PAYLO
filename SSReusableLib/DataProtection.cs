using System.Security.Cryptography;
using System.Text;

namespace SSReusableLib
{
    public class DataProtection
    {
        private string Key { get; set; }
        private string IV { get; set; }

        public static string Encrypt(string plainText)
        {
            string rtnEncryptData = string.Empty;

            if (!(plainText == null))
            {
                string key = Config.Get("DataProtectionKey");
                string iv = Config.Get("DataProtectionIV");

                rtnEncryptData = Encrypt(plainText, key, iv);
            }

            return rtnEncryptData;
        }

        public static string Decrypt(string plainText)
        {
            string rtnDecryptData = string.Empty;

            if (!(plainText == null))
            {
                string key = Config.Get("DataProtectionKey");
                string iv = Config.Get("DataProtectionIV");

                rtnDecryptData = Decrypt(plainText, key, iv);
            }

            return rtnDecryptData;
        }

        public static string Encrypt(string plainText, string key, string iv)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = Encoding.UTF8.GetBytes(iv);

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }
                    return Convert.ToHexString(msEncrypt.ToArray());
                }
            }
        }

        public static string Decrypt(string cipherText, string key, string iv)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = Encoding.UTF8.GetBytes(iv);

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromHexString(cipherText)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
