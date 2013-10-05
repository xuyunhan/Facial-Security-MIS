using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacialSecurity.EncryptionAlgorithms;

namespace FacialSecurity
{
	class KeysFactory
	{
		//加密解密的工厂类
		public string TransNormalStringToAESString(string originalStr)
		{
			var AESObj = new AES();
			return AESObj.Encrypt(originalStr);
		}

		public string TransAESStringToNormalString(string encryptedString)
		{
			var AESObj = new AES();
			return AESObj.Decrypt(encryptedString);
		}

		public string TransToMD5String(string originalStr)
		{
			var MD5Obj = new MD5();
			return MD5Obj.TransToMD5(originalStr);
		}

		public string GenerateRandomStrongPassword()
		{
			var ranStrPwObj = new RandomStrongPassword();
			return ranStrPwObj.GenerateRandomStrongPassword();
		}
	}
}
