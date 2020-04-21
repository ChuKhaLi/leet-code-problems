using System;
using System.Text;

namespace _2.AddTwoNumber
{
    class Program
    {
        /// <summary>
        /// 2. Add Two Numbers
        /// https://leetcode.com/problems/add-two-numbers/
        /// You are given two non-empty linked lists representing two non-negative integers.
        /// The digits are stored in reverse order and each of their nodes contain
        /// a single digit. Add the two numbers and return it as a linked list.
        /// You may assume the two numbers do not contain any leading zero, except the number 0 itself.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var number1 = ListNode.GenerateNode(2, 4, 3);
            var number2 = ListNode.GenerateNode(5, 6, 4);

            var sum = AddTwoNumbers(number1, number2);

            Console.WriteLine(sum);
            Console.ReadKey();
        }

        private static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var result = new ListNode(0);
            var current = result;

            int carry = 0;

            while (l1 != null || l2 != null)
            {
                current.val = (l1?.val ?? 0) + (l2?.val ?? 0) + carry;
                carry = current.val / 10;
                current.val = current.val % 10;

                l1 = l1?.next;
                l2 = l2?.next;

                if (l1 != null || l2 != null)
                {
                    current.next = new ListNode(0);
                    current = current.next;
                    continue;
                }

                if (carry == 0)
                {
                    continue;
                }

                current.next = new ListNode(carry);
                break;
            }

            return result;
        }
    }
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }

        public override string ToString()
        {
            var current = this;
            var sb = new StringBuilder();
            sb.Append("[");
            while (current != null)
            {
                sb.Append(current.val + ", ");
                current = current.next;
            }

            string result = sb.ToString();
            result = result.Substring(0, result.Length - 2);
            result += "]";

            return result;
        }

        public static ListNode GenerateNode(params int [] numbers)
        {
            var node = new ListNode(numbers[0]);
            var current = node;
            for (int i = 1; i < numbers.Length; i++)
            {
                current.next = new ListNode(numbers[i]);
                current = current.next;
            }

            return node;
        }
    }
}
