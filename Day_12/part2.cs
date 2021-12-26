class AdventOfCode2021
{
  public const string inputPath = @"C:\Users\Marina Rusu\source\repos\AdventOfCode2021\AdventOfCode2021\input.txt";
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
  static List<string> v = new() { "start" };
  static int count = 0;
  static void VisitCaves(string top, List<string> visited, bool visitedASmallCaveTwice)
  {
    if (top == "end")
    {
      ++count;
      return;
    }
    foreach (string value in map[top])
    {
      if (value.Any(a => char.IsLower(a)))
      {

        if (value == "start")
          continue;

        if (visitedASmallCaveTwice == false || !visited.Contains(value))
        {
          if (visited.Contains(value))
          {
            visitedASmallCaveTwice = true;
            VisitCaves(value, visited, visitedASmallCaveTwice);
            visitedASmallCaveTwice = false;
          }
          else
          {
            visited.Add(value);
            VisitCaves(value, visited, visitedASmallCaveTwice);
            visited.Remove(value);
          }
        }
      }
      else
      {
        VisitCaves(value, visited, visitedASmallCaveTwice);
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
    VisitCaves("start", visited, false);

    System.Console.WriteLine(count);

  }
}
