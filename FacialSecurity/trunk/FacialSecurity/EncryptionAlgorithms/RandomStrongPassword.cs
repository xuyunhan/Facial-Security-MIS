using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace FacialSecurity.EncryptionAlgorithms
{
    internal class RandomStrongPassword
    {
        public string GenerateRandomStrongPassword()
        {
            //todo::返回随机生成的强密码
            string[] oldpassword = new string[4];
            oldpassword[0] = "abcdefg";
            oldpassword[1] = "ABCDEFG";
            oldpassword[2] = "1234567";
            oldpassword[3] = "~!@#$%^";
            char[]dui=new char[8];
            char[] cuo = new char[8];
           
            var milong = 8;          //限定强密码的长度为8
            string password = "";   // 生成的强密码存放在此变量中

            char[] chs = new char[milong];  // chs 用于存放强密码的字符组
            Random t = new Random();        //随机函数

            //这个循环用于保证密码包含四种字符.
            for (int i = 0; i < oldpassword.Length; i++)         //特定字符存放到强字符组的0,1,2,3位置
            {
                int idx = (t.Next(0,oldpassword[i].Length-1));   //用第i个字符串，产生选定字符所在的位置
                 dui= oldpassword[i].ToArray();                  //把第i个字符串分成字符存放到数组中
                chs[i] = dui[idx];                               //把选定字符所在的位置的字符存放到强字符数组中
            }
            //这个循环用于保证密码的长度.
            for (int i = oldpassword.Length; i < milong; i++)    //特定字符存放到强字符组的4,5,6，7位置
            {
                int arrIdx = (t.Next(0,oldpassword.Length-1));         //选定第i个字符串
                int strIdx = (t.Next(oldpassword[arrIdx].Length-1));  //选定第i个字符串的特定字符的位置
                cuo = oldpassword[arrIdx].ToArray();                 //把第i个字符串分成字符存放到数组中
                chs[i] = cuo[strIdx];                                 //把选定字符所在的位置的字符存放到强字符数组中
            }
            // 打乱 chs 的顺序（不同的字符随机存放）
            for( int i=0 ; i <1000 ; i++ ){
            int idx1 = ( t.Next(0,chs.Length-1) );
            int idx2 = ( t.Next(0,chs.Length-1) );
            if( idx1 == idx2 ){
            continue ;
             }
            char tempChar = chs[ idx1 ] ;
            chs[ idx1 ] = chs[ idx2 ] ;
            chs[ idx2 ] = tempChar ;
             }
            password = new String( chs );
            return password;



        }
    }
}
