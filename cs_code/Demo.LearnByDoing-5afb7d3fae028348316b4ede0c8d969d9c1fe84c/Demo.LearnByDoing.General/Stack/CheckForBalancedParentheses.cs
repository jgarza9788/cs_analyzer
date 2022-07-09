using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.LearnByDoing.General.Stack
{
    /// <summary>
    /// Check for balanced parentheses using stack
    /// https://youtu.be/QZOLb0xHB_Q?list=PL2_aWCzGMAwLPEZrZIcNEq9ukGWPfLT4A
    /// </summary>
    public class CheckForBalancedParentheses
    {
        public static void Main(string[] args)
        {
            string[] parentheses = {
                "[()()]",
                "[(])",
                ")(",
                "[()]",
                "{()[]}",
            };

            List<bool> balanced = CheckBalanced(parentheses).ToList();
            for (int i = 0; i < balanced.Count; i++)
            {
                Console.WriteLine("{0} is balanced = {1}", parentheses[i], balanced[i]);
            }
        }

        private static IEnumerable<bool> CheckBalanced(string[] parentheses)
        {
            foreach (string parenthesis in parentheses)
            {
                yield return IsBalanced(parenthesis);
            }
        }

        private static HashSet<char> openingParentheses = new HashSet<char> {'(', '[', '{'};
        private static HashSet<char> closingParentheses = new HashSet<char> {')', ']', '}'};
        private static Dictionary<char, char> map = new Dictionary<char, char>
        {
            {'(', ')' }, {'[', ']' }, {'{', '}' }
        };

        private static bool IsBalanced(string parenthesis)
        {
            Stack<char> stack = new Stack<char>(parenthesis.Length);
            foreach (char c in parenthesis)
            {
                if (openingParentheses.Contains(c))
                    stack.Push(c);
                else if (closingParentheses.Contains(c))
                {
                    if (stack.Count == 0 || map[stack.Peek()] != c)
                        return false;

                    stack.Pop();
                }
            }

            return stack.Count == 0;
        }
    }
}
