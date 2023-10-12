namespace Unit2.Solution;
public class Sorting {
    #region BubbleSort
    static public void BubbleSort<T>(T[] array) where T : IComparable
    {
        var somethingChanged = true;
        while (somethingChanged)
        {
            somethingChanged = false;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i].CompareTo(array[i + 1]) > 0)
                {
                    var temp = array[i + 1];
                    array[i + 1] = array[i];
                    array[i] = temp;
                    somethingChanged = true;
                }
            }
        }
    }
    public static void DebugBubbleSort()
    {
        int[] a = new int[] { 2, 3, 7, 1, 8, 5, 6, 12 };
        Console.WriteLine($"Before {string.Join(',',a)}");
        BubbleSort(a);
        Console.WriteLine($"After {string.Join(',', a)}");

    }
    #endregion

    #region InsertionSort
    static public void InsertionSort<T>(T[] array) where T : IComparable
    {
        for (int j = 1; j < array.Length; j++)
        {
            var key = array[j];
            var i = j - 1;
            while (i >= 0 && array[i].CompareTo(key) > 0)
            {
                array[i + 1] = array[i];
                i = i - 1;
            }
            array[i + 1] = key;
        }
    }

    static public void ReverseInsertionSort<T>(T[] array) where T : IComparable
    {
        for (int j = 1; j < array.Length; j++)
        {
            var key = array[j];
            var i = j - 1;
            while (i >= 0 && array[i].CompareTo(key) < 0)
            {
                array[i + 1] = array[i];
                i = i - 1;
            }
            array[i + 1] = key;
        }
    }

    public static void DebugInsertionSort(){
        int[] a = new int[] { 2, 3, 7, 1, 8, 5, 6, 12 };
        Console.WriteLine($"Before {string.Join(',', a)}");
        InsertionSort(a);
        Console.WriteLine($"After {string.Join(',', a)}");
        ReverseInsertionSort(a);
        Console.WriteLine($"Inverse {string.Join(',', a)}");
    }
    #endregion

    #region MergeSort
    static public void MergeSort<T>(T[] array, int low, int high) where T : IComparable
    {
        if (low < high)
        {
            var middle = (low + high) / 2;
            MergeSort<T>(array, low, middle);
            MergeSort<T>(array, middle + 1, high);
            Merge<T>(array, low, middle, high);
        }
    }

    static public void Merge<T>(T[] array, int low, int middle, int high) where T : IComparable
    {
        var lengthPart1 = middle - low + 1;
        var lengthPart2 = high - middle;
        T[] part1 = new T[lengthPart1];
        T[] part2 = new T[lengthPart2];
        for (int index = 0; index < lengthPart1; index++)
            part1[index] = array[low + index];
        for (int index = 0; index < lengthPart2; index++)
            part2[index] = array[middle + 1 + index];
        var i = 0;
        var j = 0;
        for (int k = low; k <= high; k++)
        {
            if (i < lengthPart1 && j < lengthPart2)
            {
                if (part1[i].CompareTo(part2[j]) <= 0)
                {
                    array[k] = part1[i];
                    i = i + 1;
                }
                else
                {
                    array[k] = part2[j];
                    j = j + 1;
                }
            }
            else if (i >= lengthPart1)
            {
                array[k] = part2[j];
                j = j + 1;
            }
            else
            {
                array[k] = part1[i];
                i = i + 1;
            }
        }
    }

    public static void DebugMergeOnly()
    {
        int[] a = new int[] { 1, 3, 7, 8, 5, 6, 9, 12 };
        Merge(a, 0, 3, a.Length - 1);
        a = new int[] { 4, 6, 9, 1, 5 };
        Merge(a, 0, 2, a.Length - 1);
        a = new int[] { 3, 4, 6, 8, 9, 1, 2, 3, 5, 10 };
        Merge(a, 0, 4, a.Length - 1);
        a = new int[] { 2, 3, 7, 1, 8, 5, 6, 12 };
        Merge(a, 0, 3, a.Length - 1);
        a = new int[] { 5, 2, 3, -7, 1, -8, -5, -6, 12 };
        Merge(a, 5, 6, 8);
    }

    public static void DebugMergeSort() {
        int[] a = new int[] { 2, 3, 7, 1, 8, 5, 6, 12 };
        MergeSort(a, 0, a.Length - 1);
    }
    #endregion

}