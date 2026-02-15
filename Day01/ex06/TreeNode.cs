namespace ex06;

public class TreeNode
{
    public TreeNode? Parent { get; set; }

    public List<TreeNode> Children { get; set; } = [];

    public char Value { get; set; }

    public int Index { get; set; }

    public override string ToString()
    {
        return $"{Value}-{Index}";
    }
}
