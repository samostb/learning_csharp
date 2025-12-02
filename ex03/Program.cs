using ex03;

var s = Console.ReadLine();
if (string.IsNullOrWhiteSpace(s))
    return;
var parts = s.Split(',');
var input = new int[parts.Length];
for (int i = 0; i < parts.Length; i++)
{
    var success = int.TryParse(parts[i], out input[i]);
    if (success == false)
    {
        Console.WriteLine("Error");
        return;
    }
}

Array.Sort(input);

var deck = new Deck();
for (int i = input.Length - 1; i > 0; i--)
{
    deck.PushFront(input[i]);
    deck.LastToHead();
}
if (input.Length > 1)
    deck.PushFront(input[0]);
deck.Print();

