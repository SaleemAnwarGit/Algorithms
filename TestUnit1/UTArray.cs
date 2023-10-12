using System;
using System.Linq;

using Xunit;
using Unit1.Solution;

namespace TestUnit1
{
    public class UTArray
    {
        [Fact]
        public void TestAggregate()
        {
            // Arrange
            int[] a = new int[] { 1, -2, 3, 5, 6, -7, 0, 2, 0, -3, 1, 1};
            Func<int, int, int> fMax = (int a, int b) =>  a > b ? a : b; 
            int expected = a.Max();
            
            // Act
            var actual = Arrays.Aggregate(a, fMax);

            // Assert
            Assert.StrictEqual(expected, actual);
        }
        
    }
}