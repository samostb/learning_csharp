var n = 4;

// reading
var data = new double[n*2];
var count = 0;
while (count < n*2)
{
    var s = Console.ReadLine();
    var success = double.TryParse(s, out double result);
    if (success)
    {
        data[count] = result;
        count++;
    }
    else
    {
        Console.WriteLine("Couldn't parse a number. Please, try again");
    }
}

// calc lengths
var lenghts = new double[n];
for (int i = 0; i < n; i++) 
    lenghts[i] = Math.Sqrt(Math.Pow(Math.Abs(data[i*2] - data[((i + 1) * 2) % (n*2 - 2)]), 2) + Math.Pow(Math.Abs(data[i*2 + 1] - data[(i*2 + 3)% n*2]), 2));
var d = Math.Sqrt(Math.Pow(Math.Abs(data[0] - data[n]), 2) + Math.Pow(Math.Abs(data[1] - data[n + 1]), 2));

// calc squarts
var p = (lenghts[0] + lenghts[1] + d) / 2;
var square1 = Math.Sqrt(p * (p - lenghts[0]) * (p - lenghts[1]) * (p - d));
p = (lenghts[2] + lenghts[3] + d) / 2;
var square2 = Math.Sqrt(p * (p - lenghts[2]) * (p - lenghts[3]) * (p - d));

// result
Console.WriteLine($"Square = {square1 + square2:.##}");
 