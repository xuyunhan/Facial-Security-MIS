using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//扑克牌游戏。用计算机模拟洗牌，分发给4个玩家并将4个玩家的牌显示出来。
//基本思路：用一维数组Card存放52张牌（不考虑大、小王），二维数组Player存放4个玩家的牌。
//用三位整数表示一张扑克牌，最高位表示牌的种类，后两位表示牌号。例如：
//101，102，…，113分别表示红桃A，红桃2，…，红桃K。
//201，202，…，213分别表示方块A，方块2，…，方块K。
//301，302，…，313分别表示梅花A，梅花2，…，梅花K。
//401，402，…，413分别表示黑桃A，黑桃2，…，黑桃K。

namespace Test_Card
{
    class Program
    {
        static void Main(string[] args)
        {
            int  [] card = new int [52];
            //int i = 1;
            //for(;i<=4;i++)
            //    for (int j = 1; j <= 13; j++)
            //        for(int p=0;p<=51;p++)
         //       {
                    //if (j <= 9)
                    //{
                    //    card[p] = i.ToString() + "0" + j.ToString();
                    //    Console.WriteLine(value: card[0]);
                    //}
                    //else
                    //{
                    //    card[p] = i.ToString()  + j.ToString();
 
                    //}

                    
              //  }

              

       //     Console.WriteLine(value: card[34]);


//对每张牌进行赋值
            for (int i = 0; i < 52;i++)
            {
                if (i>=0 & i<=12)
                {
                    card[i] = 101 + i;
                }
                else if (i>=13 & i<=25)
                {
                    card[i] = 188 + i;
                }
                else if (i>=26 & i<=38)
                {
                    card[i] = 275 + i;
                }
                else
                {
                    card[i] = 362 + i;
                }
            }

           int [,] people = new int[4, 13];
     Random a=new Random();
           int temp;
            int test_test = 0;
            int [] test_array=new int[52];
             for (int t = 0; t <= 3;t++ )
                for (int q = 0; q <= 12; q++)
                {
                start:    temp = a.Next(0,52);
                         test_array[test_test] = temp;
                    for (int i = 0; i < test_test; i++)
                    {
                        if (temp == test_array[i])
                        {
                            goto start;

                        }
                        

                    }
                    people[t, q] = card[temp];
                    test_test++;


                }


        for (int t = 0; t <= 3; t++)
            {
                for (int q = 0; q <= 12; q++)
                {
                    Console.Write("  " + people[t, q]);
                }
                Console.WriteLine();
            }

        }
    }
}
