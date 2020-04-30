using System;

namespace _9.PalindromeNumber
{
    class Program
    {
        /// <summary>
        /// 9. Palindrome Number
        /// Determine whether an integer is a palindrome. An integer is a palindrome
        /// when it reads the same backward as forward.
        /// Follow up:
        /// Coud you solve it without converting the integer to a string?
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int x = 123321;

            Console.WriteLine($"x is palindrome: {IsPalindrome(x)}");
        }

        public static bool IsPalindrome(int x)
        {
            if (x < 0)
            {
                return false;
            }

            return x == Reverse(x);
        }

        public static int Reverse(int x)
        {
            int result = 0;
            while (x != 0)
            {
                int temp = result * 10 + (x % 10);
                result = temp;
                x /= 10;
            }

            return result;
        }
    }
}
