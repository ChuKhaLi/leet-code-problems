using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _20.ValidParentheses
{
    class Program
    {
        /// <summary>
        /// 20. Valid Parentheses
        /// https://leetcode.com/problems/valid-parentheses/
        /// Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        /// An input string is valid if:
        ///     Open brackets must be closed by the same type of brackets.
        ///     Open brackets must be closed in the correct order.
        ///     Note that an empty string is also considered valid.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var listTest = new string[]
            {
                "()",
                "()[]{}",
                "(]",
                "([)]",
                "{[]}",
                "",
                "}"
            };

            foreach (var input in listTest)
            {
                Console.WriteLine($"{input} is valid parentheses: {IsValid(input)}");
            }

            Console.ReadKey();
        }

        public static bool IsValid(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return true;
            }

            var brackets = new Dictionary<char, char>
            {
                ['('] = ')', ['['] = ']', ['{'] = '}'
            };

            var stack = new Stack<char>();

            foreach (var c in input)
            {
                if (brackets.Keys.Contains(c))
                {
                    stack.Push(brackets[c]);
                    continue;
                }

                if (stack.Count == 0 || c != stack.Pop())
                {
                    return false;
                }
            }

            return stack.Count == 0;
        }
    }
}
