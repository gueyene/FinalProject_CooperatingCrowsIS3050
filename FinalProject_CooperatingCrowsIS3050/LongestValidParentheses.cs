/*
* Name: Nogaye Gueye
* email:  gueyene @mail.uc.edu
* Assignment Number: Final Project
* Due Date:  12/10/2024
* Course #/Section: IS3050
* Semester / Year: Fall 2024
* Brief Description of the assignment: Final project, which will contain multiple leet code 
* solutions. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject_CooperatingCrowsIS3050
{
    /// <summary>
    /// This will prompt the user for a string of parentheses, calculates the length
    /// of the longest valid parentheses substring, and displays the result.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string of parentheses:");
            string input = Console.ReadLine();

            // Create an instance of LongestValidParentheses class and call its method
            LongestValidParentheses solution = new LongestValidParentheses();
            int result = solution.LongestValidParenthesesMethod(input);

            Console.WriteLine($"The length of the longest valid parentheses substring is: {result}");
        }
    }
    /// <summary>
    /// This class contains methods for solving the "Longest Valid Parentheses" problem.
    /// </summary>
    public class LongestValidParentheses
    {
        /// <summary>
        /// Determines the length of the longest valid (well-formed) parentheses substring in the input string.
        /// </summary>
        /// <param name="s">The input string containing parentheses.</param>
        /// <returns>The length of the longest valid parentheses substring</returns>
        public int LongestValidParenthesesMethod(string s)
        {
            Stack<int> st = new Stack<int>();
            st.Push(-1);
            int maxLen = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    st.Push(i);
                }
                else
                {
                    st.Pop();
                    if (st.Count == 0)
                    {
                        st.Push(i);
                    }
                    else
                    {
                        maxLen = Math.Max(maxLen, i - st.Peek());
                    }
                }
            }

            return maxLen;
        }
    }
}