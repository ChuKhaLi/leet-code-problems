using System;
using System.Collections.Generic;

namespace _14.LongestCommonPrefix
{
    class Program
    {
        /// <summary>
        /// 14. Longest Common Prefix
        /// https://leetcode.com/problems/longest-common-prefix/
        /// Write a function to find the longest common prefix string amongst an array of strings.
        /// If there is no common prefix, return an empty string "".
        /// Note:
        /// All given inputs are in lowercase letters a-z.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var testList = new List<List<string>>
            {
                new List<string>{ "flower", "flow", "flight" },
                new List<string>{ "dog", "racecar", "car" }
            };

            testList.ForEach(test =>
            {
                Console.WriteLine($"{string.Join(", ", test)} " +
                    $"{LongestCommonPrefix(test.ToArray())}");
            });

            Console.ReadKey();
        }

        public static string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0)
            {
                return string.Empty;
            }

            int minIndex = 0, len = strs.Length, minLen = strs[0].Length;

            for (var i = 0; i < len; i++)
            {
                if (strs[i].Length >= minLen)
                {
                    continue;
                }

                minIndex = i;
                minLen = strs[i].Length;
            }

            string prefix = string.Empty;

            for (var i = 0; i < minLen; i++)
            {
                var c = strs[minIndex][i];

                for (var j = 0; j < len; j++)
                {
                    if (strs[j][i] != c)
                    {
                        return prefix;
                    }
                }

                prefix += c;
            }

            return prefix;
        }
    }
}
