using System.Collections.Generic;
using System.IO;
using System.Linq;

class AdventOfCode2021
{
  public const string inputPath = @"C:\Users\Marina\source\repos\AdventOfCode2021\AdventOfCode2021\input.txt";
  public const string outputPath = @"C:\Users\Marina Rusu\source\repos\AdventOfCode2021\AdventOfCode2021\output.txt";

  static void PrintMatrix(int[,] energylevels, int n, int m)
  {
    for (int i = 0; i <= n; i++)
    {
      for (int j = 0; j <= m; j++)
      {
        System.Console.Write("{0} ", energylevels[i, j]);
      }
      System.Console.WriteLine();
    }
    System.Console.WriteLine("--------------------------------------------------------------------------------");
  }

  static Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
  //static List<string> visited = new List<string>();
  static List<string> v = new() { "start" };
  static int count = 0;
  static void VisitCaves(string top, List<string> visited)
  {
    if (top == "end")
    {
      v.Clear();
      ++count;
      return;
    }

    foreach (string value in map[top])
    {
      if (!visited.Contains(value))
      {
        if (value.Any(a => char.IsLower(a)))
        {
          visited.Add(value);
        }
        v.Add(value);
        //System.Console.Write($"{value} ");
        VisitCaves(value, visited);
        visited.Remove(value);
      }
    }

  }

  static void Main(string[] args)
  {
    string[] lines = File.ReadAllLines(inputPath);
    foreach (string line in lines)
    {
      var result = line.Split("-");
      if (!map.ContainsKey(result[0]))
      {
        map.Add(result[0], new List<string>());
      }
      if (!map.ContainsKey(result[1]))
      {
        map.Add(result[1], new List<string>());
      }
      map[result[0]].Add(result[1]);
      map[result[1]].Add(result[0]);
    }

    List<string> visited = new List<string>() { "start" };
    VisitCaves("start", visited);

    System.Console.WriteLine(count);

  }
}