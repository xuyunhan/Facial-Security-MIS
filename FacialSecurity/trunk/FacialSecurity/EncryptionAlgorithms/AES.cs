using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace FacialSecurity
{
	class AES
	{
		//用AES-256bit加解密的类

        private AesManaged myAes = new AesManaged();

        public string Encrypt(string originalStr)//加密函数
        {
            string result = "";
            ICryptoTransform encryptor = myAes.CreateEncryptor(myAes.Key, myAes.IV);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(originalStr);
                    }
                    result = System.Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
            return result;
        }

        public string Decrypt(string encryptedString)//解密函数
        {
            byte[] cipherText = System.Convert.FromBase64String(encryptedString);
            string result = "";
            ICryptoTransform decryptor = myAes.CreateDecryptor(myAes.Key, myAes.IV);

            using (MemoryStream msDecrypt = new MemoryStream(cipherText))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        result = srDecrypt.ReadToEnd();
                    }
                }
            }
            return result;
        }
    }
}
