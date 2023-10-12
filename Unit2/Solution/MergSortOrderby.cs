namespace Unit2.Solution;

public record Student(string Name, string LastName, int Age);

class MergeSortOrderby{
    static public void MergeSort<T, U>(
        T[] array,
        Func<T, U> projection,
        int low, int high) where U : IComparable
    {
        if (low < high)
        {
            var middle = (low + high) / 2;
            MergeSort(array, projection, low, middle);
            MergeSort(array, projection, middle + 1, high);
            Merge(array, projection, low, middle, high);
        }
    }

    static public void Merge<T, U>(
        T[] array,
        Func<T, U> projection,
        int low,
        int middle,
        int high) where U : IComparable
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
                if ((projection(part1[i])).CompareTo(projection(part2[j])) <= 0)
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

    public static void Debug()
    {
        Student[] a = new Student[]
        {
    new Student ("John", "Doe",  24 ),
    new Student ("Jane", "Doe",  20 ),
    new Student ("Arcturus", "Mengsk",  52 ),
    new Student ("Jim", "Raynor",  35 ),
    new Student ("Carl", "Johnson",  26 ),
    new Student ("Ace", "Ventura",  30 ),
    new Student ("Carrie", "Fisher",  19 ),
        };

        Console.WriteLine( $"Before\n{string.Join<Student>("\n", a)}");
        Func<Student, string> f = new Func<Student, string>(s => s.Name);
        
        MergeSort(a, f, 0, a.Length - 1);

        Console.WriteLine($"After\n{string.Join<Student>("\n", a)}");
    }
}
