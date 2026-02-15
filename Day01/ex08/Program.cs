using ex08;

var facultet = ParseStudents();

var b = Console.ReadLine();
if (string.IsNullOrWhiteSpace(b))
    return;

var success = int.TryParse(b, out int inputGroup);
if (!success)
{
    Console.WriteLine("Couldn't parse a number. Please, try again");
    return;
}

PrintStudents(facultet, inputGroup);

Dictionary<int, List<Student>>? ParseStudents()
{
    var s = Console.ReadLine();
    var success = int.TryParse(s, out int possitionCount);
    if (!success || possitionCount <= 0)
    {
        Console.WriteLine("Couldn't parse a number. Please, try again");
        return null;
    }


    var dictionary = new Dictionary<int, List<Student>>();
    var correctCount = 0;
    while (correctCount != possitionCount)
    {
        var pos = Console.ReadLine();
        var k = pos?.IndexOf(' ');
        if (k == null || k == -1)
        {
            Console.WriteLine("Try again");
            continue;
        }

        var name = pos![..k.Value];
        var groupStr = pos![(k.Value + 1)..];
        success = int.TryParse(groupStr, out int group);
        if (!success)
        {
            Console.WriteLine("Couldn't parse a number. Please, try again");
            continue;
        }


        var student = new Student(name, group);
        var find = dictionary.TryGetValue(group, out var students);
        if (find)
            students!.Add(student);
        else
            dictionary[group] = [student];

        correctCount++;
    }

    return dictionary;
}

void PrintStudents(Dictionary<int, List<Student>> facultet, int group)
{
    var students = facultet[group];
    var names = students.Select(s => s.Name);
    Console.WriteLine(string.Join(", ", names));
}
