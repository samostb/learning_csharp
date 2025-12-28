using ex06;

{
    var parents = ParseParents(Console.ReadLine());
    var values = Console.ReadLine();
    var root = BuildTree(parents, values);
    Print(root);
    var findLeafs = FindLeafs(root);
}

int[] ParseParents(string? s)
{
    if (string.IsNullOrWhiteSpace(s))
        return [];
    var parts = s.Split(',');
    var parents = new int[parts.Length];
    for (int i = 0; i < parts.Length; i++)
    {
        var success = int.TryParse(parts[i], out parents[i]);
        if (!success)
        {
            Console.WriteLine("Error");
            return [];
        }
    }
    return parents;
}

TreeNode? BuildTree(int[] parents, string? values)
{
    if (string.IsNullOrWhiteSpace(values) || parents.Length != values.Length || parents.Length == 0)
        return null;
    var nodes = new TreeNode[parents.Length];
    var root = new TreeNode
    {
        Index = 0,
        Parent = null,
        Children = [],
        Value = values[0]
    };
    nodes[0] = root;
    for (int i = 1; i < parents.Length; i++)
    {
        var node = new TreeNode
        {
            Index = i,
            Parent = nodes[parents[i]],
            Children = [],
            Value = values[i]
        };
        node.Parent.Children.Add(node);
        nodes[i] = node;
    }
    return root;
}
 
void Print(TreeNode? root)
{
    if (root == null)
        return;
    Console.Write($"{root}: ");
    foreach (var child in root.Children)
        Console.Write($"{child}, ");
    Console.WriteLine();
    foreach (var child in root.Children)
        Print(child);
}

// Листья
List<TreeNode> FindLeafs(TreeNode? root)
{
    if (root.Children == null)
    {
        Console.WriteLine($"{root.Value}");
    }
    return [];

}