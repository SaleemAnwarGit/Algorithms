namespace Unit1.Solution;
public class Arrays{
    public static void DebugArray() {
        int[] a = new int[] { 2, 3, 7, -1 };
        //Min Value     OR  //Max Value
        int Min = minValue(a);
        Console.WriteLine($"Min value of given array {string.Join(',', a)} is {Min}, Verifying {a.Min()} ");
        Func<int, int, int> fMax = (int a, int b) =>  a > b ? a : b;

        var Max = Aggregate(a, fMax);
        Console.WriteLine($"Max value of given array {string.Join(',', a)} is {Max}, Verifying {a.Max()} ");

        //Sum of All
        int Sum = sumAll(a);
        var Sum2 = Aggregate(a, (int x, int y) => x + y);
        Console.WriteLine($"Sum of the value of given array {string.Join(',', a)} is {Sum}, Verifying {Sum2}, {a.Aggregate((int x, int y) => x + y)} ");
        //Product of All
        var Prod = Aggregate(a, (int x, int y) => x * y);
        var Prod2 = a.Aggregate((int x, int y) => x * y);

        //All positive
            //Filter/Map Method
        //Product of NonZero
        var PosProduct = a.Where(_ => _ != 0).Aggregate((int x, int y) => x * y);
        //HoF
        //2D vs Jagged Array
        //Row order traversal vs column order traversal.
        //Generics
    }
    public static int minValue(int[] a){
        int min = a[0];
        for (int i = 1; i < a.Length; i++)
            if (a[i] < min)
                min = a[i];
        return min;
    }

    public static int? Aggregate(int[]a, Func<int, int, int> fun) {
        if (a is null || a.Length == 0) return null;
        var val = a[0];
        for (var i = 1; i < a.Length; ++i)
            val = fun(val, a[i]);
        return val;
    }
    public static int sumAll(int[] a){
        int sum = 0;
        for (int i = 0; i < a.Length; i++)
                sum += a[i];
        return sum;
    }


    #region JaggedArray / Array of array
    public static void JaggedArray(){
        int[][] a = new int[][]{
        new int[] {1, 2, 3},
        new int[] {1, 2, 3, 4, 5},
        new int[] {1}
        };
        int[] result = countEach(a);
    }
    public static int[] countEach(int[][] a)
    {
        int[] countArray = new int[a.Length];
        for (int i = 0; i < a.Length; i++){
            countArray[i] = a[i].Length;
        }
        return countArray;
    }
    #endregion

    #region ND Array or Multi-dimensional Array
    public static void NDArray(){
        int[,] m = new int[3, 4] {
        {1, 2, 5, 4},
        {2, 3, 4, 1},
        {3, 4, 3, 1}
      };
        int[] result = sumColumns(m);
    }

    public static int[] sumColumns(int[,] m){
        int[] sumCol = new int[m.GetLength(1)];
        for (int i = 0; i < m.GetLength(1); i++){
            for (int j = 0; j < m.GetLength(0); j++){
                sumCol[i] += m[j, i];
            }
        }
        return sumCol;
    }
    #endregion
}

