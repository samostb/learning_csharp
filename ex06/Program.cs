using ex06;
using System.IO;

try
{
    var parents = ParseParents(Console.ReadLine());
    var values = Console.ReadLine();
    var root = BuildTree(parents, values);
    Print(root);
    var leafs = new List<TreeNode>(10);
    FindLeafs(root, leafs);

    Console.WriteLine("===================");
    var maxPath = new List<TreeNode>(10);
    foreach (TreeNode l in leafs)
    {
        var path = new List<TreeNode>(10);
        PathFind(l, path, maxPath);
        if (maxPath.Count < path.Count)
        {
            maxPath.Clear();
            maxPath.AddRange(path);
        }

        PrintPath(path);
        Console.WriteLine("***");
    }

    Console.WriteLine("------------------");
    PrintPath(maxPath);
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
    return;
}



int[] ParseParents(string? s)
{
    if (string.IsNullOrWhiteSpace(s))
        return [];
    var parts = s.Split(',');
    var parents = new int[parts.Length];
    for (int i = 0; i < parts.Length; i++)
        parents[i] = int.Parse(parts[i]);
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
void FindLeafs(TreeNode? node, List<TreeNode> leafs)
{
    if (node == null)
        return;
    if (node.Children.Count == 0)
    {
        leafs.Add(node);
    }
    else
    {
        foreach (var child in node.Children)
            FindLeafs(child, leafs);
    }
}

void PathFind(TreeNode? node, List<TreeNode> path, List<TreeNode> maxPath)
{
    if (node == null)
        return;

    if (path.Count > 0 && path.Last().Value == node.Value)
    {
        if (maxPath.Count < path.Count)
        {
            maxPath.Clear();
            maxPath.AddRange(path);
        }

        path.Clear();
    }

    path.Add(node);
    PathFind(node.Parent, path, maxPath);
}

void PrintPath(List<TreeNode> path)
{
    foreach (var p in path)
        Console.WriteLine($"{p}, ");
}
