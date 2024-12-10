/* # Name:
# email:
# Assignment Title: Assignment nn
# Due Date:
# Course: IS 3050
# Semester/Year:
# Brief Description: This project ...
# Citations:
# Anything else that's relevant:
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
    }



}
