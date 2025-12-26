namespace ex05;

public class TextRow
{
    public string Text { get; set; }

    public int Index { get; set; }

    public override string ToString()
    {
        return $"{Index}: {Text}";
    }
}
