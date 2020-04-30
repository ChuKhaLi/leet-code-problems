using System;
using System.Collections.Generic;

namespace _13.RomanToInteger
{
    class Program
    {
        /// <summary>
        /// 13. Roman to Integer
        /// https://leetcode.com/problems/roman-to-integer/
        /// Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
        /// Symbol Value
        /// I             1
        /// V             5
        /// X             10
        /// L             50
        /// C             100
        /// D             500
        /// M             1000
        /// For example, two is written as II in Roman numeral, just two one's added together. Twelve is written as, XII, which is simply X + II. The number twenty seven is written as XXVII, which is XX + V + II.
        /// Roman numerals are usually written largest to smallest from left to right.However, the numeral for four is not IIII. Instead, the number four is written as IV.Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX.There are six instances where subtraction is used:
        /// I can be placed before V (5) and X(10) to make 4 and 9. 
        /// X can be placed before L(50) and C(100) to make 40 and 90. 
        /// C can be placed before D(500) and M(1000) to make 400 and 900.
        /// Given a roman numeral, convert it to an integer.Input is guaranteed to be within the range from 1 to 3999.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var listTest = new Dictionary<string, int>
            {
                ["III"] = 3,
                ["IV"] = 4,
                ["IX"] = 9,
                ["LVIII"] = 58,
                ["MCMXCIV"] = 1994
            };

            foreach (var romanNumber in listTest.Keys)
            {
                int decimalNumber = RomanToInt(romanNumber);
                Console.WriteLine($"{romanNumber} = {listTest[romanNumber]} got {decimalNumber}");
            }

            Console.ReadKey();
        }

        public static int RomanToInt(string input)
        {
            var lookup = new Dictionary<char, int>
            {
                ['I'] = 1,
                ['V'] = 5,
                ['X'] = 10,
                ['L'] = 50,
                ['C'] = 100,
                ['D'] = 500,
                ['M'] = 1000
            };

            int result = 0, index = 0, len = input.Length;

            var listInt = new int[len];
            foreach (char c in input)
            {
                listInt[index++] = lookup[c];
            }

            index = 0;

            while (index < len - 1)
            {
                int x1 = listInt[index], x2 = listInt[index + 1];

                if (x1 < x2)
                {
                    result = result + x2 - x1;
                    index += 2;
                    continue;
                }

                result = result + x1;
                index++;
            }

            if (index == len - 1)
            {
                result += listInt[index];
            }

            return result;
        }
    }
}
