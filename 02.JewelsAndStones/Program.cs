using System;
using System.Collections.Generic;

namespace _02.JewelsAndStones
{
    class Program
    {
        /// <summary>
        /// Day 02. Jewels and Stones
        /// https://leetcode.com/explore/challenge/card/may-leetcoding-challenge/534/week-1-may-1st-may-7th/3317/
        /// You're given strings J representing the types of stones that are jewels, and S representing the stones you have.  Each character in S is a type of stone you have.  You want to know how many of the stones you have are also jewels.
        /// The letters in J are guaranteed distinct, and all characters in J and S are letters. Letters are case sensitive, so "a" is considered a different type of stone from "A".
        /// Example 1:
        /// Input: J = "aA", S = "aAAbbbb"
        /// Output: 3
        /// Example 2:
        /// Input: J = "z", S = "ZZ"
        /// Output: 0
        /// Note:
        /// S and J will consist of letters and have length at most 50.
        /// The characters in J are distinct.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var testList = new[]
            {
                new
                {
                    jewels = "aA",
                    stones = "aAAbbbb",
                    count = 3
                },
                new
                {
                    jewels = "z",
                    stones = "ZZ",
                    count = 0
                }
            };

            foreach (var test in testList)
            {
                int count = NumJewelsInStones(test.jewels, test.stones);

                Console.WriteLine($"jewels {test.jewels}");
                Console.WriteLine($"stones {test.stones}");
                Console.WriteLine($"expected {test.count}");
                Console.WriteLine($"output {count}");
                Console.WriteLine($"success {count == test.count}");
            }

            Console.ReadKey();
        }

        public static int NumJewelsInStones(string jewels, string stones)
        {
            int count = 0;

            var jewelMap = new HashSet<char>(jewels);

            foreach (var stone in stones)
            {
                if (jewelMap.Contains(stone))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
