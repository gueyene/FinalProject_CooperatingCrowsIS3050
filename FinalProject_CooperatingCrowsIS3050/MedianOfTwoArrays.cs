/* Name: Andrea Gauthier
* email: gauthiaj@mail.uc.edu
* Assignment Number: Final Project
* Due Date:  12/10/2024
* Course #/Section: IS3050
* Semester / Year: Fall 2024
* Brief Description of the assignment: Final project
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject_CooperatingCrowsIS3050
{
    public class MedianOfTwoArrays
    {
        /// <summary>
        /// Finds the median of two sorted arrays.
        /// </summary>
        /// <param name="nums1">The first sorted array.</param>
        /// <param name="nums2">The second sorted array.</param>
        /// <returns>The median of the two sorted arrays.</returns>
        /// <exception cref="ArgumentException">Thrown if the input arrays are not sorted correctly.</exception>
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            // Ensuring nums1 is the smaller array
            if (nums1.Length > nums2.Length)
            {
                return FindMedianSortedArrays(nums2, nums1); // Recursively call the method with the arrays swapped
            }

            int m = nums1.Length, n = nums2.Length; // Get the lengths of both arrays
            int low = 0, high = m; // Initialize binary search bounds for the smaller array

            // Binary search on the smaller array
            while (low <= high)
            {
                // Partition the smaller array (nums1) and the larger array (nums2)
                int partitionX = (low + high) / 2;
                int partitionY = (m + n + 1) / 2 - partitionX; // The partition index for nums2

                // Determine the maximum and minimum elements on each side of the partitions
                int maxX = (partitionX == 0) ? int.MinValue : nums1[partitionX - 1]; // Left side of nums1
                int minX = (partitionX == m) ? int.MaxValue : nums1[partitionX]; // Right side of nums1

                int maxY = (partitionY == 0) ? int.MinValue : nums2[partitionY - 1]; // Left side of nums2
                int minY = (partitionY == n) ? int.MaxValue : nums2[partitionY]; // Right side of nums2

                // If the partition is correct (i.e., the left side elements are smaller or equal to the right side elements)
                if (maxX <= minY && maxY <= minX)
                {
                    // If the total length of both arrays is even, the median is the average of the middle two elements
                    // If the total length is odd, the median is the larger of the max elements from the left partitions
                    return (m + n) % 2 == 0
                        ? (Math.Max(maxX, maxY) + Math.Min(minX, minY)) / 2.0
                        : Math.Max(maxX, maxY);
                }
                else if (maxX < minY)
                {
                    // If maxX is smaller than minY, it means we need to move the partition of nums1 to the right
                    low = partitionX + 1;
                }
                else
                {
                    // If maxX is greater than minY, it means we need to move the partition of nums1 to the left
                    high = partitionX - 1;
                }
            }

            // If the input arrays are not sorted or there is an error, throw an exception
            throw new ArgumentException("Input arrays are not sorted.");
        }
    }
}