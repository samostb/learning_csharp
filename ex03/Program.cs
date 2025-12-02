using ex03;

var s = Console.ReadLine();
var parts = s.Split(',');
var deck1 = new int[parts.Length];
for (int i = 0; i < parts.Length; i++)
{
    var success = int.TryParse(parts[i], out deck1[i]);
    if (success == false)
    {
        Console.WriteLine("Error");
        return;
    }
}

Array.Sort(deck1);

var deck = new Deck();
deck.PushFront(1);
deck.PushFront(2);
deck.PushBack(3);
deck.Print();


