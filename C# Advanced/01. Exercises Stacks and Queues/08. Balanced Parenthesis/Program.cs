using System;
using System.Collections.Generic;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        const char CurlyBracketsOpen = '{';
        const char CurlyBracketsClose = '}';
        const char SquareBracketsOpen = '[';
        const char SquareBracketsClose = ']';
        const char RoundBracketsOpen = '(';
        const char RoundBracketsClose = ')';
        const string ResultNo = "NO";
        const string ResultYes = "YES";

        static void Main(string[] args)
        {
            var stack = new Stack<char>();
            var input = Console.ReadLine().Trim();
            var isValid = true;

            foreach (var ch in input)
            {
                if (ch == CurlyBracketsOpen || ch == SquareBracketsOpen || ch == RoundBracketsOpen)
                {
                    stack.Push(ch);
                }
                else if (ch == CurlyBracketsClose || ch == SquareBracketsClose || ch == RoundBracketsClose)
                {
                    if (stack.Count == 0)
                    {
                        isValid = false;
                        break;
                    }

                    var stackPeak = stack.Pop();

                    if (!IfCloseParenthesesAreCorrect(stackPeak, ch))
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            if (isValid)
            {
                Console.WriteLine(ResultYes);
            }
            else
            {
                Console.WriteLine(ResultNo);
            }
        }

        private static bool IfCloseParenthesesAreCorrect(char stackPeak, char ch)
        {
            var isCorrect = false;

            if (stackPeak == RoundBracketsOpen && ch == RoundBracketsClose)
            {
                isCorrect = true;
            }
            else if (stackPeak == CurlyBracketsOpen && ch == CurlyBracketsClose)
            {
                isCorrect = true;
            }
            else if (stackPeak == SquareBracketsOpen && ch == SquareBracketsClose)
            {
                isCorrect = true;
            }

            return isCorrect;
        }
    }
}
