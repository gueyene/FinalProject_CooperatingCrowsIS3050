﻿/* # Name:Cooperating Crows
# email: gauthiaj@mail.uc.edu
# Assignment Title: Final Project 
# Due Date: 12/10/2024
# Course: IS 3050
# Semester/Year: Fall 2024
# Brief Description: This project is the final in our class that solves problems
# Citations: ChatGPT
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject_CooperatingCrowsIS3050
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlProblems_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProblem = ddlProblems.SelectedValue;

            // Reset form
            lblSolution.Text = "";
            lblCodeExecuted.Text = "";
            txtArray1.Text = "";
            txtArray2.Text = "";
            txtInput.Text = "";
            btnSolve.Visible = true;

            // Hide all input panels
            pnlMedianInputs.Visible = false;
            pnlSingleInput.Visible = false;
            pnlRegexInputs.Visible = false;
            

            // Display relevant input and problem description
            if (selectedProblem == "Median")
            {
                lblProblemDescription.Text = "Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.";
                pnlMedianInputs.Visible = true;
            }
            else if (selectedProblem == "Binary")
            {
                lblProblemDescription.Text = "Given a m x n binary matrix mat. In one step, you can choose one cell and flip it and all the four neighbors of it if they exist. Return the minimum steps to convert mat to a zero matrix.";
            }
            else if (selectedProblem == "Parentheses")
            {
                lblProblemDescription.Text = "Given a string of parentheses, find the length of the longest valid (well-formed) parentheses substring.";
                pnlSingleInput.Visible = true; // Show the correct panel
            }
            else if (selectedProblem == "Regex")
            {
                lblProblemDescription.Text = "Given a string and a regular expression pattern, determine if the string matches the pattern.";
                pnlRegexInputs.Visible = true;
            }
            else
            {
                lblProblemDescription.Text = "";
                btnSolve.Visible = false; // Hide the Solve button if no valid problem is selected
            }
        }


        // Solve Button Click Handler
        protected void btnSolve_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedProblem = ddlProblems.SelectedValue;

                if (selectedProblem == "Median")
                {
                    int[] nums1 = txtArray1.Text.Split(',').Select(int.Parse).ToArray();
                    int[] nums2 = txtArray2.Text.Split(',').Select(int.Parse).ToArray();

                    double median = FindMedianSortedArrays(nums1, nums2);
                    lblSolution.Text = $"The median is: {median}";
                    lblCodeExecuted.Text = @"
                    public double FindMedianSortedArrays(int[] nums1, int[] nums2) 
                    { 
                    if (nums1.Length > nums2.Length)
                    {
                         return FindMedianSortedArrays(nums2, nums1);
                    }

                        int m = nums1.Length, n = nums2.Length;
                        int low = 0, high = m;

                        while (low <= high)
                    {
                         int partitionX = (low + high) / 2;
                         int partitionY = (m + n + 1) / 2 - partitionX;

                         int maxX = (partitionX == 0) ? int.MinValue : nums1[partitionX - 1];
                         int minX = (partitionX == m) ? int.MaxValue : nums1[partitionX];

                         int maxY = (partitionY == 0) ? int.MinValue : nums2[partitionY - 1];
                         int minY = (partitionY == n) ? int.MaxValue : nums2[partitionY];

                         if (maxX <= minY && maxY <= minX)
                    {
                      return (m + n) % 2 == 0
                          ? (Math.Max(maxX, maxY) + Math.Min(minX, minY)) / 2.0
                            : Math.Max(maxX, maxY);
                    }
                         else if (maxX < minY)
                    {
                         low = partitionX + 1;
                    }
                         else
                    {
                         high = partitionX - 1;
                    }
                    }

                        throw new ArgumentException(""Input arrays are not sorted."");
                    } 
                    }";
                }
                else if (selectedProblem == "Binary")
                {
                    int[][] mat = new int[2][] { new int[] { 0, 0 }, new int[] { 0, 1 } };
                    int steps = MinFlips(mat);
                    lblSolution.Text = steps == -1
                        ? "Cannot convert to zero matrix."
                        : $"Minimum Steps: {steps}";
                    lblCodeExecuted.Text = @"
                public int MinFlips(int[][] mat) 
                { 
                 int m = mat.Length, n = mat[0].Length;
                 int all = 1 << (m * n);
                 int res = int.MaxValue;

                 for (int mask = 0; mask < all; mask++)
                 {
                int[][] temp = mat.Select(row => row.ToArray()).ToArray();
                int flipCount = 0;

                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        int bitIndex = i * n + j;
                        if ((mask & (1 << bitIndex)) != 0)
                        {
                            Flip(temp, i, j);
                            flipCount++;
                        }
                    }
                }

                if (IsZeroMatrix(temp))
                {
                    res = Math.Min(res, flipCount);
                }
            }

            return res == int.MaxValue ? -1 : res;
            }";
                }
                else if (selectedProblem == "Parentheses")
                {
                    string input = txtInput.Text;
                    LongestValidParentheses solver = new LongestValidParentheses();
                    int result = solver.LongestValidParenthesesMethod(input);

                    lblSolution.Text = $"The length of the longest valid parentheses substring is: {result}";
                    lblCodeExecuted.Text = @"
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
                     }";
                }

                else if (selectedProblem == "Regex")
                {
                    string input = txtInput.Text;  // Input string
                    string pattern = txtRegexPattern.Text;  // Regex pattern

                    // Call SolveRegexMatching method
                    string result = SolveRegexMatching(input, pattern);

                    // Display result
                    lblSolution.Text = result;
                    lblCodeExecuted.Text = @"
                    public string SolveRegexMatching(string input, string pattern) 
            { 
                bool IsMatch(string s, string p)
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
                    return dp[m, n];}";
                }
                   
                
            }
            catch (Exception)
            {
                lblSolution.Text = "Error: Please enter valid input.";
            }
        }

        // Median of Two Sorted Arrays
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1.Length > nums2.Length)
            {
                return FindMedianSortedArrays(nums2, nums1);
            }

            int m = nums1.Length, n = nums2.Length;
            int low = 0, high = m;

            while (low <= high)
            {
                int partitionX = (low + high) / 2;
                int partitionY = (m + n + 1) / 2 - partitionX;

                int maxX = (partitionX == 0) ? int.MinValue : nums1[partitionX - 1];
                int minX = (partitionX == m) ? int.MaxValue : nums1[partitionX];

                int maxY = (partitionY == 0) ? int.MinValue : nums2[partitionY - 1];
                int minY = (partitionY == n) ? int.MaxValue : nums2[partitionY];

                if (maxX <= minY && maxY <= minX)
                {
                    return (m + n) % 2 == 0
                        ? (Math.Max(maxX, maxY) + Math.Min(minX, minY)) / 2.0
                        : Math.Max(maxX, maxY);
                }
                else if (maxX < minY)
                {
                    low = partitionX + 1;
                }
                else
                {
                    high = partitionX - 1;
                }
            }

            throw new ArgumentException("Input arrays are not sorted.");
        }

        // Minimum Steps to Zero Matrix
        public int MinFlips(int[][] mat)
        {
            int m = mat.Length, n = mat[0].Length;
            int all = 1 << (m * n);
            int res = int.MaxValue;

            for (int mask = 0; mask < all; mask++)
            {
                int[][] temp = mat.Select(row => row.ToArray()).ToArray();
                int flipCount = 0;

                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        int bitIndex = i * n + j;
                        if ((mask & (1 << bitIndex)) != 0)
                        {
                            Flip(temp, i, j);
                            flipCount++;
                        }
                    }
                }

                if (IsZeroMatrix(temp))
                {
                    res = Math.Min(res, flipCount);
                }
            }

            return res == int.MaxValue ? -1 : res;
        }

        private void Flip(int[][] mat, int i, int j)
        {
            int[][] directions = { new int[] { 0, 0 }, new int[] { 1, 0 }, new int[] { -1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 } };

            foreach (var dir in directions)
            {
                int x = i + dir[0], y = j + dir[1];
                if (x >= 0 && x < mat.Length && y >= 0 && y < mat[0].Length)
                {
                    mat[x][y] ^= 1;
                }
            }
        }

        private bool IsZeroMatrix(int[][] mat) => mat.All(row => row.All(cell => cell == 0));

        public class LongestValidParentheses
        {
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

        // Solve Regex Matching method using dynamic programming
        public string SolveRegexMatching(string input, string pattern)
        {
            bool IsMatch(string s, string p)
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

            bool isMatch = IsMatch(input, pattern);  // Check for regex match
            return isMatch ? "Match found!" : "No match";  // Return result
        }



    }
              


}
