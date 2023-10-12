namespace Unit1;
class TestMain {
    public static void Main() {
        //Solution.Searching.DebugBinarySearch();
        //Solution.Arrays.DebugArray();
    }
}
public interface ISearching { //Cant be done with static methods in .net6 c#10,  Needs higher version
    int binarySearch<T>(T[] a, T v) where T : IComparable;
    int binarySearchRecursive<T>(T[] a, int low, int high, T v) where T : IComparable;
}