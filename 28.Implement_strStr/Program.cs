using System;

namespace _28.Implement_strStr
{
    class Program
    {
        /// <summary>
        /// 28. Implement strStr()
        /// https://leetcode.com/problems/implement-strstr/
        /// Implement strStr().
        /// Return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.
        /// Example 1:
        /// Input: haystack = "hello", needle = "ll"
        /// Output: 2
        /// Example 2:
        /// Input: haystack = "aaaaa", needle = "bba"
        /// Output: -1
        /// Clarification:
        /// What should we return when needle is an empty string? This is a great question to ask during an interview.
        /// For the purpose of this problem, we will return 0 when needle is an empty string. This is consistent to C's strstr() and Java's indexOf().
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var testList = new[]
            {
                //new {haystack = "hello", needle = "ll", index = 2},
                //new {haystack = "aaaaa", needle = "bba", index = -1},
                //new {haystack = "aaa", needle = "aaa", index = 0},
                new {haystack = "mississippi", needle = "issip", index = 4},
            };

            foreach (var test in testList)
            {
                int index = StrStr(test.haystack, test.needle);
                Console.WriteLine($"haystack {test.haystack} needle {test.needle}");
                Console.WriteLine($"result {index} expected {test.index}");
                Console.WriteLine($"success: {index == test.index}");
            }

            Console.ReadKey();
        }

        public static int StrStr(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(needle))
            {
                return 0;
            }

            int index = 0, stackLen = haystack.Length, needleLen = needle.Length;
            while (index < stackLen - needleLen + 1)
            {
                bool found = true;
                int i;
                for (i = 0; i < needleLen; i++)
                {
                    if (haystack[index + i] != needle[i])
                    {
                        found = false;
                        break;
                    }
                }

                if (found)
                {
                    return index;
                }

                index ++;
            }

            return -1;
        }
    }
}
