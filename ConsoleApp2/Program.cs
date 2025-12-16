{
    var lines = ReadFile("input.txt");

    CountOfLines(lines);
    Console.Write("Input search word: ");
    var s = Console.ReadLine();
    var detection = Detection(s, lines);
    Print(detection.Lines, detection.Count);
    PrintToFile(detection.Lines, detection.Count, "result.txt");
}

List<string> ReadFile(string path)
{
    using var stream = File.OpenRead(path);
    using var reader = new StreamReader(stream);

    var lines = new List<string>(10);
    var line = reader.ReadLine();
    while (line != null)
    {
        lines.Add(line);
        line = reader.ReadLine();
    }
    return lines;
}

(List<string> Lines, int Count) Detection(string? s, List<string> lines)
{
    if (string.IsNullOrEmpty(s))
        return ([], 0);
    var detectedCount = 0;
    var detectedLines = new List<string>(10);
    foreach (var l in lines)
    {
        var startIndex = l.IndexOf(s);
        if (startIndex >= 0)
            detectedLines.Add(l);
        while (startIndex >= 0)
        {
            detectedCount++;
            startIndex = l.IndexOf(s, startIndex + s.Length);
        }
    }
    return (detectedLines, detectedCount);
}

void Print(List<string> detectedLines, int detectedCount)
{
    foreach (var d in detectedLines)
        Console.WriteLine($"{d}");
    Console.Write($"=== {detectedCount} ===");
}

void PrintToFile(List<string> detectedLines, int detectedCount, string path)
{
    using var stream = File.OpenWrite(path);
    using var writer = new StreamWriter(stream);

    foreach (var d in detectedLines)
        writer.WriteLine($"{d}");
    writer.Write($"=== {detectedCount} ===");
}

void CountOfLines(List<string> lines)
{
    for (int i = 0; i < lines.Count; i++)
    {
        Console.WriteLine($"{i + 1}) {lines[i]}");
    }
    Console.WriteLine();
    return;
}
