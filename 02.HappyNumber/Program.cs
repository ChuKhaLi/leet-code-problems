using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.HappyNumber
{
    class Program
    {
        /// <summary>
        /// Day 02. Happy Number
        /// Write an algorithm to determine if a number n is "happy".
        /// A happy number is a number defined by the following process: Starting with any positive integer, replace the number by the sum of the squares of its digits, and repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1. Those numbers for which this process ends in 1 are happy numbers.
        /// Return True if n is a happy number, and False if not.
        /// Example: 
        /// Input: 19
        /// Output: true
        /// Explanation: 
        /// 1^2 + 9^2 = 82
        /// 8^2 + 2^2 = 68
        /// 6^2 + 8^2 = 100
        /// 1^2 + 0^2 + 0^2 = 1
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var testList = new[] {57, 9, 99, 999};

            foreach (var number in testList)
            {
                GenerateHappyNumber(number, 20);
                Console.WriteLine(IsHappy(number));
            }

            Console.ReadKey();
        }

        public static bool IsHappy(int n)
        {
            var repeated = new HashSet<int>();
            
            while (n != 1)
            {
                n = n.ToString()
                    .Select(x => x - '0')
                    .Sum(x => x * x);

                if (repeated.Contains(n))
                {
                    return false;
                }

                repeated.Add(n);
            }

            return true;
        }

        public static int GenerateHappyNumber(int number, int repeat)
        {
            Console.WriteLine("step\tnumber");
            int step = 1;
            while (step <= repeat)
            {
                Console.WriteLine($"{step}\t{number}");

                if (number == 1)
                {
                    break;
                }

                number = number.ToString()
                    .Select(x => x - '0')
                    .Sum(x => x * x);

                step++;
            }

            return number;
        }
    }
}
