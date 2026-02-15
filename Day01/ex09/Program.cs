using ex09;

var a = new MyList<int?>();
a.Add(1);
a.Add(2);
a.Add(3);
a.Add(4);
a.Add(5);
a.Add(6);
a.Add(7);
a.Remove(2);
a.Add(15);
a.Print();
if (a.Count() != 7)
    Console.WriteLine("Beda");



a.Remove(1);
a.Remove(15);
a.Print();


a.Remove(5);
a.Remove(6);
a.Print();

a.Remove(999);
a.Remove(4);
a.Remove(7);
a.Print();

a.Add(3);
a.Remove(3);
a.Print();

a.Remove(3);
a.Remove(3);
a.Print();

a.Add(3);
a.Print();


a.Add(3);
a.Add(3);
a.Add(3);
a.Add(3);
a.Add(3);
a.Add(3);
a.Add(3);
a.Add(3);
a.Add(3);
a.Add(3);
a.Add(3);
a.Add(3);
a.Add(3);
a.Add(3);
a.Add(3);
a.Add(3);
a.Add(3);
a.Add(3);
a.Add(3);
a.Add(3);
a.Add(3);
a.Add(3);
a.Add(3);
a.Add(3);
a.Add(3);
a.Add(3);
a.Print();
Console.WriteLine("---------------");

var b = new MyList<int>();
b.Add(1);
b.Add(2);
b.Add(3);
foreach (var x in b)
{
    Console.WriteLine(x);
}
