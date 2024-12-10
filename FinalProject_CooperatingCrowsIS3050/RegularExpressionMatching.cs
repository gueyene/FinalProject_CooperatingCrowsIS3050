/*
 * Name: Madison Geier
* email: geierml@mail.uc.edu
* Assignment Number: Final Project
* Due Date:   12/10/24
* Course #/Section: IS3050 001
* Semester/Year:   Fall 2024
* Brief Description of the assignment: Creating a class with a hard level problem
* Citations: Gemini, Chat GTP, Leet

 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject_CooperatingCrowsIS3050
{
    public class RegularExpressionMatching
    {
        // Method for regular expression matching
        public static bool IsMatch(string s, string p)
        {
            int m = s.Length;
            int n = p.Length;

            // Create a 2D DP array to store results of subproblems
            bool[,] dp = new bool[m + 1, n + 1];

            // Base case: Empty string matches empty pattern
            dp[0, 0] = true;

            // Handle cases where pattern starts with a '*' (which can match empty string)
            for (int j = 1; j <= n; j++)
            {
                if (p[j - 1] == '*')
                {
                    dp[0, j] = dp[0, j - 2];
                }
            }

            // Fill the DP table
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (p[j - 1] == s[i - 1] || p[j - 1] == '.')
                    {
                        dp[i, j] = dp[i - 1, j - 1]; // If characters match or there's a '.'
                    }
                    else if (p[j - 1] == '*')
                    {
                        // If '*' is used, we have two cases:
                        // 1. Treat '*' as matching zero characters, i.e., dp[i, j - 2]
                        // 2. If the character before '*' matches the current character in 's', we treat '*' as matching one or more characters.
                        dp[i, j] = dp[i, j - 2] || (dp[i - 1, j] && (s[i - 1] == p[j - 2] || p[j - 2] == '.'));
                    }
                }
            }

            // The answer is whether the entire string 's' matches the entire pattern 'p'
            return dp[m, n];
        }

        // Test method to test regular expression matching
        public static void RunTests()
        {
            // Test case 1: "aa" matches "a" (Expected: false)
            Console.WriteLine("Test 1: " + (IsMatch("aa", "a") ? "Passed" : "Failed"));

            // Test case 2: "aa" matches "a*" (Expected: true)
            Console.WriteLine("Test 2: " + (IsMatch("aa", "a*") ? "Passed" : "Failed"));

            // Test case 3: "ab" matches ".*" (Expected: true)
            Console.WriteLine("Test 3: " + (IsMatch("ab", ".*") ? "Passed" : "Failed"));

            // Test case 4: "mississippi" matches "mis*is*p*." (Expected: false)
            Console.WriteLine("Test 4: " + (IsMatch("mississippi", "mis*is*p*.") ? "Passed" : "Failed"));

            // Test case 5: "aab" matches "c*a*b" (Expected: true)
            Console.WriteLine("Test 5: " + (IsMatch("aab", "c*a*b") ? "Passed" : "Failed"));

            // Test case 6: "a" matches ".*a" (Expected: true)
            Console.WriteLine("Test 6: " + (IsMatch("a", ".*a") ? "Passed" : "Failed"));
        }

        // The following method could be used if you're testing in a console environment
        public static void Main(string[] args)
        {
            RunTests();
        }
    }
}
