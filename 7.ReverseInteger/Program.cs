using System;
using System.Collections.Generic;

namespace _7.ReverseInteger
{
    class Program
    {
        /// <summary>
        /// 7. Reverse Integer
        /// https://leetcode.com/problems/reverse-integer/
        /// Given a 32-bit signed integer, reverse digits of an integer.
        /// Note:
        /// Assume we are dealing with an environment which could only
        /// store integers within the 32-bit signed integer range:[−2^31,  2^31 − 1].
        /// For the purpose of this problem, assume that your function returns 0
        /// when the reversed integer overflows.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int test = 1534236469;
            int revered = Reverse(test);

            Console.WriteLine(revered);
            Console.ReadKey();
        }

        public static int Reverse(int x)
        {
            int result = 0;
            while (x != 0)
            {
                int temp = result * 10 + (x % 10);
                if (result != temp / 10)
                {
                    return 0;
                }
                result = temp;
                x /= 10;
            }

            return result;
        }
    }
}
