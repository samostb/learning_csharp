var strs = File.ReadAllLines("input.txt");
var matrix = ParseMatrix(strs);
if (matrix == null)
{
    return;
}

PrintMatrix(matrix);
Calc(matrix);
PrintMatrix(matrix);
PrintAnswers(matrix);



double[][]? ParseMatrix(string[] s)
{
    double[][] matrix = new double[s.Length][];

    // fill matrix
    for (int i = 0; i < s.Length; i++)
    {
        var parts = s[i].Split(' ');
        matrix[i] = new double[parts.Length];
        for (int j = 0; j < parts.Length; j++)
        {
            var success = int.TryParse(parts[j], out var result);
            if (success)
            {
                matrix[i][j] = result;
            }
            else
            {
                Console.WriteLine("Error");
                return null;
            }
        }
    }

    return matrix;
}

void PrintMatrix(double[][] m)
{
    Console.WriteLine("==========================");
    for (int i = 0; i < m.Length; i++)
    {
        for (int j = 0; j < m[i].Length; j++)
        {
            Console.Write($"{m[i][j], 6} ");
        }
        Console.WriteLine();
    }
    Console.WriteLine("==========================");
}

void PrintAnswers(double[][] m)
{
    for (int i = 0; i < m.Length; i++)
    {
        int row = i;
        int col = m[i].Length - 1;
        Console.WriteLine($"x{i + 1} = {m[row][col],3}");
    }
}

void Calc(double[][] m)
{
    for (int i = 0; i < m.Length; i++)
    {
        var d = m[i][i];
        for (int j = i; j < m[i].Length; j++)
        {
            m[i][j] /= d;
        }

        for (int n = i + 1; n < m.Length; n++)
        {
            var p = m[n][i];
            for (int j = i; j < m[n].Length; j++)
            {
                m[n][j] = m[n][j] - p * m[i][j];
            }
        }
        for (int o = i - 1; o >= 0; o--)
        {
            var p = m[o][i];
            for (int j = i; j < m[o].Length; j++)
            {
                m[o][j] = m[o][j] - p * m[i][j];
            }
        }
    }
}