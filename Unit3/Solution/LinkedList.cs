namespace Unit3.Solution;

public class Node<T> where T : IComparable {
    public T Value { get; }
    public Node<T> Next { get; set; }

    public Node(T value, Node<T> next){
        this.Value = value;
        this.Next = next;
    }
}

public class LinkedList<T> where T : IComparable
{
    public Node<T> start;

    public LinkedList()=>   start = null;
    public LinkedList(Node<T> node) => start = node;

    public Node<T> Search(T value)
    {
        Node<T> curr = start;
        while (curr != null && curr.Value.CompareTo(value) != 0)
            curr = curr.Next;

        return curr;
    }

    public void Insert(T value)
    {
        if (start == null || start.Value.CompareTo(value) >= 0)
        {
            start = new Node<T>(value, start);
            return;
        }

        Node<T> curr = start;
        while (curr.Next != null && curr.Next.Value.CompareTo(value) < 0)
            curr = curr.Next;
        curr.Next = new Node<T>(value, curr.Next);
    }

    public void Delete(T value){
        if (start == null || start.Value.CompareTo(value) > 0) // element is not in the list
            return;
        else if (start.Value.CompareTo(value) == 0)
        { // element to delete is the first 
            start = start.Next;
            return;
        }

        Node<T> curr = start;
        while (curr.Next != null && curr.Next.Value.CompareTo(value) <= 0)
        {
            if (curr.Next.Value.CompareTo(value) == 0)
            {
                curr.Next = curr.Next.Next;
                return;
            }
            curr = curr.Next;
        }
    }
}

public class DebugLinkedList
{
    public static void Debug()
    {
        //Needs some carefull planning here and for testing too
        var list =
          new LinkedList<int>(
            new Node<int>(
              5, new Node<int>(
                7, new Node<int>(
                  21, new Node<int>(
                    30, null)
                  )
                )
              )
          );
        list.Insert(12);
        list.Insert(2);
        list.Delete(21);
        var a = 21;
        var fr = list.Search(a);

        var list2 = new LinkedList<string>();
        list2.Delete("hello");
    }
}