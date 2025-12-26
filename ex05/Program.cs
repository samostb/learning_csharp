using ex05;

{
    var lines = ReadFile("input.txt");

    Console.Write("Input search word: ");
    var s = Console.ReadLine();
    var detection = Detection(s, lines);
    Print(detection.Lines, detection.Count);
    PrintToFile(detection.Lines, detection.Count, "result.txt");
}

List<TextRow> ReadFile(string path)
{
    using var stream = File.OpenRead(path);
    using var reader = new StreamReader(stream);

    var lines = new List<TextRow>(10);
    var line = reader.ReadLine();
    var rowIndex = 1;
    while (line != null)
    {
        lines.Add(new TextRow
        {
            Text = line,
            Index = rowIndex++,
        });
        line = reader.ReadLine();
    }
    return lines;
}

(List<TextRow> Lines, int Count) Detection(string? s, List<TextRow> lines)
{
    if (string.IsNullOrEmpty(s))
        return ([], 0);
    var detectedCount = 0;
    var detectedLines = new List<TextRow>(10);
    foreach (var l in lines)
    {
        var startIndex = l.Text.IndexOf(s);
        if (startIndex >= 0)
            detectedLines.Add(l);
        while (startIndex >= 0)
        {
            detectedCount++;
            startIndex = l.Text.IndexOf(s, startIndex + s.Length);
        }
    }
    return (detectedLines, detectedCount);
}

void Print(List<TextRow> detectedLines, int detectedCount)
{
    foreach (var d in detectedLines)
        Console.WriteLine(d);
    Console.Write($"=== {detectedCount} ===");
}

void PrintToFile(List<TextRow> detectedLines, int detectedCount, string path)
{
    using var stream = File.OpenWrite(path);
    using var writer = new StreamWriter(stream);

    foreach (var d in detectedLines)
        writer.WriteLine(d);
    writer.Write($"=== {detectedCount} ===");
}
