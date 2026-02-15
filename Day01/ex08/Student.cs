namespace ex08;

internal class Student
{
    public Student(string name, int group)
    {
        Name = name;
        Group = group;
    }

    public string Name { get; set; } = "";

    public int Group { get; set; }
}
