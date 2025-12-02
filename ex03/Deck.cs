namespace ex03;

public class CardNode
{
    public int Value { get; set; }

    public CardNode? Next { get; set; }

    public CardNode? Prev { get; set; }
}

public class Deck
{
    public CardNode? Head { get; set; }

    public CardNode? Tail { get; set; }

    public void PushFront(int value)
    {
        var node = new CardNode
        {
            Value = value,
            Next = Head,
        };

        if (Head != null)
            Head.Prev = node;

        Head = node;
        if (Tail == null)
            Tail = node;
    }

    public void PushBack(int value)
    {
        var node = new CardNode()
        {
            Value = value,
            Prev = Tail
        };
        if (Tail != null)
            Tail.Next = node;
        Tail = node;

        if (Head == null)
            Head = node;
    }

    public int? PopFront()
    {
        if (Head == null)
            return null;
        var hn = Head.Next;
        Head.Next = null;
        if (hn != null)
            hn.Prev = null;

        var val = Head.Value;
        Head = hn;
        if (Head == null)
            Tail = null;
        return val;
    }

    public int? PopBack()
    {
        if (Tail == null)
            return null;
        var tp = Tail.Prev;
        Tail.Prev = null;
        if (tp != null)
            tp.Next = null;

        var val = Tail.Value;
        Tail = tp;
        if (Tail == null)
            Head = null;
        return val;
    }

    public void Print()
    {
        var iterator = Head;
        while (iterator != null)
        {
            Console.Write($"{iterator.Value} ");
            iterator = iterator.Next;
        }
        Console.WriteLine();
    }

    public void LastToHead()
    {
        var pb = PopBack();
        if (pb == null)
            return;
        PushFront(pb.Value);
    }
}
