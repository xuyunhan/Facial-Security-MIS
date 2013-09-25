using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

//C#可以直接调用MD5算法，已经在命名空间中封装
//“System.Security.Cryptography”包含了与MD5算法相关的类。


namespace FacialSecurity
{
	class MD5
	{
		//MD5算法类
        //MD5码值是由 0~9  A~F 组成的32位长的密码。(表示数值是16进制的。)
        public string TransToMD5(string toHash)
        {
            MD5CryptoServiceProvider crypto = new MD5CryptoServiceProvider();
            //“MD5CyptoServiceProvider”类是.NET中“System.Security.Cryptography”命名空间的一个类，
            //提供专门用于MD5单向数据加密的解决方法，用来加密数据库中用户密码的类
            byte[] bytes = Encoding.UTF7.GetBytes(toHash);
            bytes = crypto.ComputeHash(bytes);
            //ComputeHash()方法用来将输入的明文数据字符数组使用MD5进行加密，
            //然后输出加密后的密文数据字符数组
            StringBuilder sb = new StringBuilder();
            foreach (byte num in bytes)//遍历
            {
                sb.AppendFormat("{0:x2}", num);//表示格式化为十六进制的数
            }
            return sb.ToString();        //返回32位的MD5码值，可存入数据库进行比对
        }
        

    }

    
}
