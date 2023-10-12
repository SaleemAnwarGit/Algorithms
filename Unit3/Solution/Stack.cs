namespace Unit3.Solution;
public class Stack<T>
{
    public int capacity;
    public int top = -1;
    public T[] array;

    public int Size()
    {
        return capacity;
    }

    public Stack(int size = 10)
    {
        capacity = size;
        array = new T[capacity];
    }

    public bool IsEmpty()
    {
        return top == -1;
    }

    public T Pop()
    {
        if (!IsEmpty()) // stack is not empty
        {
            T value = array[top];
            array[top] = default(T);
            top--;
            return value;
        }
        return default(T);
    }

    public void Push(T t)
    {
        if (top == capacity - 1) // stack is full
        {
            capacity = capacity * 2;
            var newArray = new T[capacity];
            for (int i = 0; i <= top; i++)
                newArray[i] = array[i];
            array = newArray;
        }
        array[++top] = t;
    }
}
public class DebugStack {
    private static Action<Stack<T>, T>[] RandomizeOperations<T>(int length, int? seed = null)
    {
        Action<Stack<T>, T>[] operations = new Action<Stack<T>, T>[length];
        Random r = seed == null ? new Random() : new Random(seed.Value);
        for (int i = 0; i < operations.Length; i++)
        {
            double randomValue = r.NextDouble();
            if (randomValue < 0.5)
            {
                operations[i] = (q, x) => q.Push(x);
            }
            else
            {
                operations[i] = (q, _) => q.Pop();
            }
        }
        return operations;
    }

    public static void Debug()
    {
        var r = new Random(45);
        var stack = new Stack<int>(5);
        var generatedOps = RandomizeOperations<int>(8, 45);
        var operations = generatedOps;
        for (int i = 0; i < operations.Length; i++)
        {
            operations[i](stack, r.Next(0, 100));
        }
    }
}

