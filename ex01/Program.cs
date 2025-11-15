var n = 4;
var count = 0;
var data = new double[n*2];
while  (count < n * 2)
{
    var b = Console.ReadLine();
    var correct = double.TryParse(b, out double result);
    if (correct == true)
    {
        data[count] = result;
        count++;
    }
    else
    {
        Console.WriteLine("Couldn't parse a number. Please, try again");
    }
}
var length = new double[n];
for (int i = 0; i < n; i++)
{
    length[i] = Math.Sqrt(Math.Pow(Math.Abs(data[i] - data[((i + 1) * 2) % (n * 2 - 2)]), 2) + Math.Pow(Math.Abs(data[i * 2 + 1] - data[(i * 2 + 3) % n * 2]), 2));
}
var c = Math.Sqrt(Math.Pow(Math.Abs(data[0] - data[n]), 2) + Math.Pow(Math.Abs(data[1] - data[n+1]), 2));
var p = (length[0] + length[1] + c) / 2;
var s1 = Math.Sqrt(p * (p - length[0]) * (p - length[1]) * (p - c));
p = (length[2] + length[3] + c) / 2;
var s2 = Math.Sqrt(p * (1 - length[2]) * (p - length[3]) * (p - c));
Console.WriteLine($"Square = {s1 + s2}");