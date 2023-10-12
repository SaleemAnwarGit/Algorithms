using Xunit;
using Unit1.Solution;

namespace TestUnit1
{
    public class UTSearching
    {
        [Fact]
        public void TestIntbinarySearchSuccess()
        {
            // Arrange
            int[] a = new int[] { 1, 2, 3, 5, 6, 7, 8, 12, 25, 32, 41, 48, 57, 59, 60, 75, 88, 91, 93, 94, 100 };
            int valueToSearch = 7;
            int expected = 5;

            // Act
            var actual = Searching.binarySearch(a, valueToSearch);

            // Assert
            Assert.StrictEqual(expected, actual);
            
        }
        [Fact]
        public void TestIntbinarySearchFail()
        {
            // Arrange
            int[] a = new int[] { 12, 25, 32, 41, 48, 57, 59, 60, 75, 88, 91, 93, 94, 100 };
            int valueToSearch = 7;
            int expected = -1;

            // Act
            var actual = Searching.binarySearch(a, valueToSearch);

            // Assert
            Assert.StrictEqual(expected, actual);

        }
    }
}