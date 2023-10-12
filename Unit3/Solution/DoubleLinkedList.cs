namespace Unit3.Solution;
public class DoubleLinkedList
    {
    }

public class DllNode<T> {
    public T Value { get; }
    public DllNode<T> Next { get; set; }
    public DllNode<T> Prev { get; set; }


    public DllNode(T value, DllNode<T> prev, DllNode<T> next) {
        this.Value = value;
        this.Next = next;
        this.Prev = prev;
    }
}

public class DoubleLinkedList<T>
{
    public DllNode<T> First { get; set; }
    public DllNode<T> Last { get; set; }

    public DoubleLinkedList(){
        First = Last = null;
    }

    public DllNode<T> Search(T value)
    {
        DllNode<T> curr = First;

        while (curr != null && !curr.Value.Equals(value))
        {
            curr = curr.Next;
        }
        return curr;
    }

    #region Insert Practice
    public void InsertBeginning(T value)
    {
        DllNode<T> newNode = new DllNode<T>(value, null, First);
        if (First != null) // check First
            First.Prev = newNode;
        First = newNode;
        if (Last == null) // check Last
            Last = newNode;
    }
    public void InsertBefore(DllNode<T> node, T value)
    {
        DllNode<T> newNode = new DllNode<T>(value, node.Prev, node);
        node.Prev = newNode;
        if (First == node) // check if node was the first one
            First = newNode;
        else
            newNode.Prev.Next = newNode;
    }
    public void InsertAfter(DllNode<T> node, T value)
    {
        DllNode<T> newNode = new DllNode<T>(value, node, node.Next);
        node.Next = newNode;

        if (Last == node) // check if node was the last one
            Last = newNode;
        else
            newNode.Next.Prev = newNode;
    }
    public void InsertLast(T value)
    {
        DllNode<T> newNode = new DllNode<T>(value, Last, null);
        if (Last != null) // last node is not null
            Last.Next = newNode;
        Last = newNode;
        if (First == null) // first node is null
            First = newNode;
    }
    #endregion
    //Add one method InsertSorted

    public void Remove(DllNode<T> node)
    {
        if (node.Prev != null) // check Prev
            node.Prev.Next = node.Next;
        if (node.Next != null) // check Next
            node.Next.Prev = node.Prev;
        if (First == node) // check First
            First = node.Next;
        if (Last == node) // check Last
            Last = node.Prev;
    }
}



public class DebugDoubleLinkedList
{
    public static void Debug()
    {
        var n1 = new DllNode<int>(5, null, null);
        var n2 = new DllNode<int>(-3, n1, null);
        var n3 = new DllNode<int>(2, n2, null);
        var n4 = new DllNode<int>(-3, n3, null);
        var n5 = new DllNode<int>(4, n4, null);
        n1.Next = n2;
        n2.Next = n3;
        n3.Next = n4;
        n4.Next = n5;
        var dl1 = new DoubleLinkedList<int>();
        dl1.First = n1;
        dl1.Last = n5;
        var element = dl1.Search(5);
    }
}
