var goods = ParseGoods();
if (goods == null)
    return;
var avgSum = AvgSum(goods);

Console.WriteLine($"{avgSum:.000}");


double AvgSum(Dictionary<string, double> goods)
{
    return goods.Sum(i => i.Value) / goods.Count;
}

Dictionary<string, double>? ParseGoods()
{
    var s = Console.ReadLine();
    var success = int.TryParse(s, out int possitionCount);
    if (!success || possitionCount <= 0)
    {
        Console.WriteLine("Couldn't parse a number. Please, try again");
        return null;
    }


    var dictionary = new Dictionary<string, double>();
    while (dictionary.Count != possitionCount)
    {
        var pos = Console.ReadLine();
        var k = pos?.IndexOf(' ');
        if (k == null || k == -1)
        {
            Console.WriteLine("Try again");
            continue;
        }

        var name = pos![..k.Value];
        var priceStr = pos![(k.Value + 1)..];
        success = double.TryParse(priceStr, out double price);
        if (!success)
        {
            Console.WriteLine("Couldn't parse a number. Please, try again");
            continue;
        }

        dictionary[name] = price;
    }

    return dictionary;
}
