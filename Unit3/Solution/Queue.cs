namespace Unit3.Solution;
public class Queue<T>
{
    public int front;
    public int back;
    public T[] data;
    public int Count { get; set; } = 0;

    public bool IsEmpty
    {
        get { return Count == 0; }
    }

    public Queue(int capacity)
    {
        data = new T[capacity];
        front = -1;
        back = -1;
    }

    internal void Enqueue(T element)
    {
        if (IsEmpty) // queue is empty
        {
            data[0] = element;
            front = back = 0;
            Count++;
        }
        else if ((back + 1) % data.Length == front) // queue is full (do nothing)
        {
            return;
        }
        else
        {
            back = (back + 1) % data.Length;
            data[back] = element;
            Count++;
        }
    }

    internal T Dequeue()
    {
        if (IsEmpty) // queue is empty
        {
            return default(T);
        }
        T element = data[front]; data[front] = default(T);
        front = (front + 1) % data.Length;
        Count--;
        return element;
    }

}

public class DebugQueue
{
    private static Action<Queue<T>, T>[] RandomizeOperations<T>(int length, int? seed = null)
    {
        Action<Queue<T>, T>[] operations = new Action<Queue<T>, T>[length];
        Random r = seed == null ? new Random() : new Random(seed.Value);
        for (int i = 0; i < operations.Length; i++)
        {
            double randomValue = r.NextDouble();
            if (randomValue < 0.5)
            {
                operations[i] = (q, x) => q.Enqueue(x);
            }
            else
            {
                operations[i] = (q, _) => q.Dequeue();
            }
        }
        return operations;
    }

    public static void Debug()
    {
        var r = new Random(45);
        var queue = new Queue<int>(5);
        var generatedOps = RandomizeOperations<int>(5, 45);
        var operations = generatedOps;
        for (int i = 0; i < operations.Length; i++)
        {
            operations[i](queue, r.Next(0, 100));
        }
    }
}

