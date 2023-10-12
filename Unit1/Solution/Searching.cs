namespace Unit1.Solution;
public class Searching{
    public static int sequentialSearch(int[] a, int v){
        for (int i = 0; i < a.Length; i++)
            if (a[i] == v)
                return i;
        return -1;
    }

    public static void DebugSequentialSearch(){
        int[] a = new int[] { 2, 3, 7, 1, 8, 5, 6, 12 };
        int valueToSearch = 7;
        int result = sequentialSearch(a, valueToSearch);
    }

    public static int sequentialSearch<T>(T[] a, T v) where T : IComparable
    {
        for (int i = 0; i < a.Length; i++)
            if (a[i].CompareTo(v) == 0)
                return i;

        return -1;
    }

    public static void DebugSequentialSearchGenerics()
    {
        int[] a = new int[] { 2, 3, 7, 1, 8, 5, 6, 12 };
        int valueToSearch = 7;
        int result = sequentialSearch<int>(a, valueToSearch);
        string[] b = new string[] { "hello", "hoi", "ciao", "bye", "hallo" };
        string textToSearch = "hallo";
        int result2 = sequentialSearch<string>(b, textToSearch);
    }

    public static int binarySearch<T>(T[] a, T v) where T : IComparable
    {
        int low = 0;
        int high = a.Length - 1;
        while (low <= high)
        {
            int middle = (low + high) / 2;
            if (v.CompareTo(a[middle]) < 0)
                high = middle - 1;
            else if (v.CompareTo(a[middle]) > 0)
                low = middle + 1;
            else
                return middle;
        }
        return -1;
    }

    public static void DebugBinarySearch()
    {
        int[] a = new int[] { 1, 2, 3, 5, 6, 7, 8, 12, 25, 32, 41, 48, 57, 59, 60, 75, 88, 91, 93, 94, 100 };
        int valueToSearch = 7;
        int result = binarySearch<int>(a, valueToSearch);
        Console.WriteLine(result);

        string[] b = new string[] { "bye", "ciao", "hallo", "hello", "hoi" };
        string textToSearch = "hello";
        int result2 = binarySearch<string>(b, textToSearch);
        Console.WriteLine(result2);
    }

    public static int binarySearchRecursive<T>(T[] a, int low, int high, T v) where T : IComparable
    {
        if (low > high)
            return -1;
        int middle = (low + high) / 2;
        if (a[middle].CompareTo(v) > 0)
            return binarySearchRecursive(a, low, middle - 1, v);
        else if (a[middle].CompareTo(v) < 0)
            return binarySearchRecursive(a, middle + 1, high, v);
        else
            return middle;
    }

    public static void DebugBinarySearchRecursive()
    {
        int[] a = new int[] { 1, 2, 3, 5, 6, 7, 8, 12, 25, 32, 41, 48, 57, 59, 60, 75, 88, 91, 93, 94, 100 };
        int valueToSearch = 7;
        int result = binarySearchRecursive<int>(a, 0, a.Length - 1, valueToSearch);
        string[] b = new string[] { "bye", "ciao", "hallo", "hello", "hoi" };
        string textToSearch = "hello";
        int result2 = binarySearchRecursive<string>(b, 0, b.Length - 1, textToSearch);
    }
}
