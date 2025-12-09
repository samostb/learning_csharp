using ex04;

{
    var s = Console.ReadLine();
    var result = ParseArray(s);
    var root = ConvertToLinkedList(result);
    Print(root);

    var resultRoot = TransformList(result?.Length ?? 0, root);
    Print(resultRoot);
}


int[] ParseArray(string? h)
{
    if (string.IsNullOrWhiteSpace(h))
        return [];
    var parts = h.Split(',');
    var input = new int[parts.Length];
    for (int i = 0; i < parts.Length; i++)
    {
        var success = int.TryParse(parts[i], out input[i]);
        if (success == false)
        {
            Console.WriteLine("Error");
            return [];
        }
    }
    return input;
}

ListNode? ConvertToLinkedList(int[] array)
{
    ListNode? root = null;
    for (int i = array.Length - 1; i >= 0; i--)
    {
        root = new ListNode(array[i], root);
    }
    return root;
}

void Print(ListNode? root)
{
    ListNode? p = root;
    while (p != null)
    {
        Console.Write($"{p.val} ");
        p = p.next;
    }

    Console.WriteLine();
}

ListNode? TransformList(int count, ListNode? root)
{
    if (root == null)
        return null;

    var queue = new Queue<ListNode>(count / 2 + 1);
    var stack = new Stack<ListNode>(count / 2 + 1);

    ListNode? p = root;
    int i = 0;
    while (p != null)
    {
        if (i <= count / 2)
            queue.Enqueue(p);
        else
            stack.Push(p);

        p = p.next;
        i++;
    }

    var resultRoot = queue.Dequeue();
    var d = resultRoot;
    while (queue.Count > 0 || stack.Count > 0)
    {
        if (stack.Count > 0)
        {
            d.next = stack.Pop();
            d = d.next;
        }

        if (queue.Count > 0)
        {
            d.next = queue.Dequeue();
            d = d.next;
        }
    }
    d.next = null;

    return resultRoot;
}
