using Xunit;
using System;
using System.Linq;

using Unit2.Solution;

namespace TestUnit2
{
    public class UTSorting
    {
        [Fact]
        public void TestIntBubbleSortSuccess()
        {
            // Arrange
            int[] a = new int[] { 2, 3, 7, 1, 8, 5, 6, 12 };
            /*int[] expected= new int [a.Length];
            Array.Copy(a, expected, a.Length); 
            Array.Sort(expected);*/
            var expected = new int[] { 1, 2, 3, 5, 6, 7, 8, 12 };

            // Act
            Sorting.BubbleSort(a);

            // Assert
            Assert.Equal(expected, a);
        }
    }
}