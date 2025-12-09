using ex04;

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
List<int> list = new List<int>(input);
for (int i = 0; i < list.Count; i++)
{
    Console.WriteLine(list[i]);
}
Console.WriteLine();