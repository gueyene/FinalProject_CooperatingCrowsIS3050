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

        protected void bnSolveMedianOfTwoArrays_Click(object sender, EventArgs e)
        {
            try
            {
                // Convert the input strings into integer arrays
                int[] nums1 = Array.ConvertAll(txtArray1.Text.Split(','), int.Parse);
                int[] nums2 = Array.ConvertAll(txtArray2.Text.Split(','), int.Parse);

                // Call the median method
                double result = FindMedianSortedArrays(nums1, nums2);

                // Display the result
                lblSolveMedianOfTwoArraysSolution.Text = $"The median is: {result}";
            }
            catch (Exception)
            {
                lblSolveMedianOfTwoArraysSolution.Text = "Error: Please enter valid integers separated by commas.";
            }
        }

        // Function to find the median of two sorted arrays
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
                    if ((m + n) % 2 == 0)
                    {
                        return (Math.Max(maxX, maxY) + Math.Min(minX, minY)) / 2.0;
                    }
                    else
                    {
                        return Math.Max(maxX, maxY);
                    }
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

            throw new ArgumentException("The input arrays are not sorted.");
        }

        /// <summary>
        /// Invokes MinFlips in the class BinaryMatrixFlipper and returns the solution on button press.
        /// </summary>
        /// <param name="sender"> contains a reference to the object</param>
        /// <param name="e"> Contains the event data </param>
        protected void bnSolveBinaryMatrixFlipper_Click(object sender, EventArgs e)
        {
            BinaryMatrixFlipper BinaryMatrixFlipper = new BinaryMatrixFlipper();
            int[][] mat = new int[2][];
            mat[0] = new int[] { 0, 0 };
            mat[1] = new int[] { 0, 1 };
            int numflips = BinaryMatrixFlipper.MinFlips(mat);
            lblBinaryMatrixFlipperSolution.Text = "The number of flips required is " + numflips.ToString();
        }
    }

    

}
