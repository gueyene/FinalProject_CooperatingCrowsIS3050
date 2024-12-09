/*
*Name: Dylan Sams
* email: samsds @mail.uc.edu
* Assignment Number: finalproject_cooperatingcrows
* Due Date: 12 / 10 / 2024
* Course #/Section: IS3050-001
* Semester / Year: Fall 2024
* Brief Description of the assignment: The goal of this project is to demonstrate a mastery of basic C# programming and ASP.Net web sites

* Brief Description of what this module does. This module contains the class BinaryMatrixFlipper which contains the code for the leetcode solution 
*Citations: solution code: https://chatgpt.com/c/67560d61-1c60-800b-8c13-d5ac8d71bb77
*
*Anything else that's relevant:
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject_CooperatingCrowsIS3050
{
    public class BinaryMatrixFlipper
    {
        // Directions for flipping: up, down, left, right (4 neighbors)
        private static readonly int[] directions = { -1, 0, 1, 0, 0, -1, 0, 1 };

        /// <summary>
        /// Solves leetcode problem 1284
        /// </summary>
        /// <param name="mat"> the array to be solved</param>
        /// <returns> number of flips or -1 if unsolvable</returns>
        public int MinFlips(int[][] mat)
        {
            int m = mat.Length;
            int n = mat[0].Length;

            // If the matrix is already all zeros, no flips are required
            if (IsZeroMatrix(mat))
                return 0;

            // Create a visited set to avoid revisiting the same state
            var visited = new HashSet<string>();
            Queue<(int[][] state, int steps)> queue = new Queue<(int[][] state, int steps)>();

            // Initialize the queue with the initial state of the matrix
            queue.Enqueue((CopyMatrix(mat), 0));
            visited.Add(MatrixToString(mat));

            // BFS to find the minimum flips
            while (queue.Count > 0)
            {
                var (currentState, steps) = queue.Dequeue();

                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        int[][] nextState = CopyMatrix(currentState);
                        FlipNeighbors(nextState, i, j, m, n);

                        // If next state is all zeros, return the number of steps
                        if (IsZeroMatrix(nextState))
                            return steps + 1;

                        string nextStateString = MatrixToString(nextState);

                        // If the state has not been visited before, add to the queue
                        if (!visited.Contains(nextStateString))
                        {
                            visited.Add(nextStateString);
                            queue.Enqueue((nextState, steps + 1));
                        }
                    }
                }
            }

            // If we exit the loop, it means it's not possible to reach a zero matrix
            return -1;
        }


        /// <summary>
        /// flips the current cell and its four neighbors
        /// </summary>
        /// <param name="mat"> the array representing the matrix</param>
        /// <param name="i">The row index of the cell to flip.</param>
        /// <param name="j">The column index of the cell to flip.</param>
        /// <param name="m">The total number of rows in the matrix.</param>
        /// <param name="n">The total number of columns in the matrix.</param>
        private void FlipNeighbors(int[][] mat, int i, int j, int m, int n)
        {
            // Flip the current cell and its 4 neighbors (if within bounds)
            FlipCell(mat, i, j, m, n);

            // Loop through the 4 directions (up, down, left, right)
            for (int k = 0; k < directions.Length; k += 2)
            {
                int newRow = i + directions[k];
                int newCol = j + directions[k + 1];
                FlipCell(mat, newRow, newCol, m, n);
            }
        }

        // Helper method to flip a single cell if it's within bounds
        /// <summary>
        /// flips a single cell if it's within bounds
        /// </summary>
        /// <param name="mat"> the array that represents the matrix</param>
        /// <param name="i">The row index of the cell to flip.</param>
        /// <param name="j">The column index of the cell to flip.</param>
        /// <param name="m">The number of rows in the matrix.</param>
        /// <param name="n">The number of columns in the matrix.</param>
        private void FlipCell(int[][] mat, int i, int j, int m, int n)
        {
            if (i >= 0 && i < m && j >= 0 && j < n)
            {
                mat[i][j] ^= 1; // Flip (0 -> 1 or 1 -> 0)
            }
        }


        /// <summary>
        /// checks to see if matrix is a zero matrix
        /// </summary>
        /// <param name="mat"> the array to be checked</param>
        /// <returns> either true or false based on if it is a zero matrix</returns>
        private bool IsZeroMatrix(int[][] mat)
        {
            foreach (var row in mat)
            {
                foreach (int cell in row)
                {
                    if (cell == 1)
                        return false;
                }
            }
            return true;
        }


        /// <summary>
        /// Helper method to convert matrix to string for comparison in visited set
        /// </summary>
        /// <param name="mat"> the array to be converted</param>
        /// <returns> the array as a string</returns>
        private string MatrixToString(int[][] mat)
        {
            var sb = new System.Text.StringBuilder();

            foreach (var row in mat)
            {
                foreach (int cell in row)
                {
                    sb.Append(cell);
                }
            }
            return sb.ToString();
        }


        /// <summary>
        /// Helper method to create a copy of the matrix
        /// </summary>
        /// <param name="mat"> array to be copied</param>
        /// <returns> the copy of the array</returns>
        private int[][] CopyMatrix(int[][] mat)
        {
            int m = mat.Length;
            int n = mat[0].Length;
            int[][] copy = new int[m][];

            for (int i = 0; i < m; i++)
            {
                copy[i] = new int[n];
                Array.Copy(mat[i], copy[i], n);
            }

            return copy;
        }

    }
}