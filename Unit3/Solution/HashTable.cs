namespace Unit3.Solution;

public class Entry<K, V>
{
    public K Key { get; set; }
    public V Value { get; set; }

    public Entry(K key, V value)
    {
        Key = key;
        Value = value;
    }
}

public class HashTable<K, V>
{
    public Entry<K, V>[] buckets { get; set; }

    protected HashTable() { buckets = null; }

    public HashTable(int capacity)
    {
        buckets = new Entry<K, V>[capacity];
    }

    protected int getIndex(K key)
    {
        int hashCode = Math.Abs(key.GetHashCode());
        int index = hashCode % buckets.Length;
        return index;
    }

    public void Add(K key, V value)
    {
        int index = getIndex(key);
        if (buckets[index] == null) // the bucket is empty, we can insert
            buckets[index] = new Entry<K, V>(key, value);
        else // we have to do probing to find an empty bucket
        {
            var potentialIndex = (index + 1) % buckets.Length;
            while (buckets[potentialIndex] != null) // the bucket in position potentialIndex is not empty
            {
                if (potentialIndex == index)
                    return;
                potentialIndex++;
                if (potentialIndex >= buckets.Length)
                    potentialIndex = 0;
            }
            buckets[potentialIndex] = new Entry<K, V>(key, value);
        }
    }

    public V Find(K key)
    {
        int index = getIndex(key);

        if (buckets[index] != null && buckets[index].Key.Equals(key)) // the hashed bucket contains the key we are looking for
        {
            return buckets[index].Value;
        }
        else // the key we are looking for could be in another position: use linear probing to find it
        {
            var potentialIndex = (index + 1) >= buckets.Length ? 0 : (index + 1);
            while (potentialIndex != index)
            {
                if (buckets[potentialIndex] != null && buckets[potentialIndex].Key.Equals(key))
                {
                    return buckets[potentialIndex].Value;
                }
                potentialIndex++;
                if (potentialIndex >= buckets.Length) //wraparound required
                    potentialIndex = 0;
            }
        }
        return default(V);
    }

    public void Delete(K key)
    {
        int index = getIndex(key);
        if (buckets[index] != null && buckets[index].Key.Equals(key)) //the hashed bucket is not empty and it contains the key that we want to delete
        {
            buckets[index] = null;
        }
        else //the key we want to delete could be in another position: use linear probing to find it.
        {
            var potentialIndex = (index + 1) >= buckets.Length ? 0 : (index + 1);
            while (potentialIndex != index)
            {
                if (buckets[potentialIndex] != null && buckets[potentialIndex].Key.Equals(key))
                {
                    buckets[potentialIndex] = null;
                    return;
                }

                potentialIndex++;
                if (potentialIndex >= buckets.Length)
                    potentialIndex = 0;
            }
        }
    }
}

public class DebugHashTable
{
    public class Person
    {
        public int Age { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public Person(int age, string lastName, string firstName)
        {
            Age = age;
            LastName = lastName;
            FirstName = firstName;
        }
    }
    public static void Debug()
    {
        var table = new HashTable<string, Person>(4);
        var p1 = new Person(25, "John", "Doe");
        var p2 = new Person(19, "Jane", "Doe");
        var p3 = new Person(65, "Kurt", "Russell");
        var p4 = new Person(57, "Dolph", "Lundgren");
        var p5 = new Person(28, "Tim", "Smith");
        table.Add("083643", p1);
        table.Add("081645", p2);
        table.Add("086623", p3);
        table.Add("085348", p4);
        table.Add("085340", p5);

        var r1 = table.Find("085348");
        table.Delete("085348");
    }
}
