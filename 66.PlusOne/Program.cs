using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace _66.PlusOne
{
    class Program
    {
        /// <summary>
        /// 66. Plus One
        /// https://leetcode.com/problems/plus-one/
        /// Given a non-empty array of decimal digits representing a non-negative integer, increment one to the integer.
        /// The digits are stored such that the most significant digit is at the head of the list, and each element in the array contains a single digit.
        /// You may assume the integer does not contain any leading zero, except the number 0 itself.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var examples = new Dictionary<int[], int[]>
            {
                [new[] { 0 }] = new[] { 1 },
                [new[] { 1, 9 }] = new[] { 2, 0 },
                [new[] { 1, 2, 3 }] = new[] { 1, 2, 4 },
                [new []{ 9, 9, 9 }] = new []{1, 0, 0, 0}
            };

            foreach (var example in examples)
            {
                var result = PlusOne(example.Key);
                bool isEqual = Compare(result, example.Value);
                string answer = isEqual ? "" : $". It is{ToString(example.Value)}";
                Console.WriteLine($"{ToString(example.Key)} + 1 {(isEqual ? "is" : "is not")} {ToString(result)}{answer}");
            }

            Console.ReadLine();
        }

        private static string ToString(int[] value)
        {
            return "{" + string.Join(",", value) + "}";
        }

        private static bool Compare(int[] result, int[] value)
        {
            if (result.Length != value.Length)
            {
                return false;
            }

            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] != value[i])
                {
                    return false;
                }
            }

            return true;
        }

        static int[] PlusOne(int[] digits)
        {
            int length = digits.Length;
            int[] plusOne = new int[length];
            int carry = 0;
            int j = 0;
            for (var i = length - 1; i >= 0; i--)
            {
                int sum = digits[i] + (i == length - 1 ? 1 : 0) + carry;
                carry = sum / 10;

                plusOne[j++] = sum % 10;
            }

            if (carry != 0)
            {
                Array.Resize(ref plusOne, length + 1);
                plusOne[length] = carry;
            }

            Array.Reverse(plusOne);
            return plusOne;
        }
    }
}
