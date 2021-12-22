using System.Collections.Generic;
using System.IO;
using System.Linq;

class AdventOfCode2021
{
  public const string inputPath = @"C:\Users\Marina\source\repos\AdventOfCode2021\AdventOfCode2021\input.txt";
  public const string outputPath = @"C:\Users\Marina Rusu\source\repos\AdventOfCode2021\AdventOfCode2021\output.txt";
  static int[,] energylevels = new int[10, 10];
  static int n = -1, m = -1;
  static int flashes = 0;
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

  static int[,] Step(int stepNumber = 1)
  {
    int[] steps = new int[3] { -1, 0, 1 };
    for (int i = 0; i <= n; i++)
    {
      for (int j = 0; j <= m; j++)
      {
        energylevels[i + steps[1], j + steps[1]] += stepNumber;
      }
    }
    return energylevels;
  }

  static bool Check()
  {
    int count = 0;
    for (int i = 0; i <= n; i++)
    {
      for (int j = 0; j <= m; j++)
      {
        if (energylevels[i, j] == 0)
          ++count;
      }
    }
    if(count == (n+1)*(m+1))
      return true;
    return false;
  }

  static int[] steps = new int[3] { -1, 0, 1 };
  static Stack<KeyValuePair<int, int>> CheckAndFlashe(Stack<KeyValuePair<int, int>> stack, int i, int j, int stepNumber = 1)
  {
    ++flashes;
    energylevels[i + steps[1], j + steps[1]] = 0;
    if (i + steps[0] >= 0 && j + steps[0] >= 0 && energylevels[i + steps[0], j + steps[0]] != 0)
    {
      energylevels[i + steps[0], j + steps[0]] += stepNumber;
      if (energylevels[i + steps[0], j + steps[0]] > 9)
        stack.Push(new KeyValuePair<int, int>(i + steps[0], j + steps[0]));
    }
    if (i + steps[0] >= 0 && energylevels[i + steps[0], j + steps[1]] != 0)
    {
      energylevels[i + steps[0], j + steps[1]] += stepNumber;
      if (energylevels[i + steps[0], j + steps[1]] > 9)
        stack.Push(new KeyValuePair<int, int>(i + steps[0], j + steps[1]));
    }
    if (i + steps[0] >= 0 && j + steps[2] <= m && energylevels[i + steps[0], j + steps[2]] != 0)
    {
      energylevels[i + steps[0], j + steps[2]] += stepNumber;
      if (energylevels[i + steps[0], j + steps[2]] > 9)
        stack.Push(new KeyValuePair<int, int>(i + steps[0], j + steps[2]));
    }

    if (j + steps[0] >= 0 && energylevels[i + steps[1], j + steps[0]] != 0)
    {
      energylevels[i + steps[1], j + steps[0]] += stepNumber;
      if (energylevels[i + steps[1], j + steps[0]] > 9)
        stack.Push(new KeyValuePair<int, int>(i + steps[1], j + steps[0]));
    }
    if (j + steps[2] <= m && energylevels[i + steps[1], j + steps[2]] != 0)
    {
      energylevels[i + steps[1], j + steps[2]] += stepNumber;
      if (energylevels[i + steps[1], j + steps[2]] > 9)
      {
        stack.Push(new KeyValuePair<int, int>(i + steps[1], j + steps[2]));
      }
    }

    if (i + steps[2] <= n && j + steps[0] >= 0 && energylevels[i + steps[2], j + steps[0]] != 0)
    {
      energylevels[i + steps[2], j + steps[0]] += stepNumber;
      if (energylevels[i + steps[2], j + steps[0]] > 9)
      {
        stack.Push(new KeyValuePair<int, int>(i + steps[2], j + steps[0]));
      }
    }
    if (i + steps[2] <= n && energylevels[i + steps[2], j + steps[1]] != 0)
    {
      energylevels[i + steps[2], j + steps[1]] += stepNumber;
      if (energylevels[i + steps[2], j + steps[1]] > 9)
      {
        stack.Push(new KeyValuePair<int, int>(i + steps[2], j + steps[1]));
      }
    }
    if (i + steps[2] <= n && j + steps[2] <= m && energylevels[i + steps[2], j + steps[2]] != 0)
    {
      energylevels[i + steps[2], j + steps[2]] += stepNumber;
      if (energylevels[i + steps[2], j + steps[2]] > 9)
      {
        stack.Push(new KeyValuePair<int, int>(i + steps[2], j + steps[2]));
      }
    }
    return stack;
  }

  static int[,] Flashes()
  {

    for (int i = 0; i <= n; i++)
    {
      for (int j = 0; j <= m; j++)
      {
        Stack<KeyValuePair<int, int>> stack = new();
        if (energylevels[i + steps[1], j + steps[1]] == 10)
        {
          CheckAndFlashe(stack, i, j);
        }

        List<KeyValuePair<int, int>> visited = new();
        while (stack.Any())
        {
          var top = stack.Pop();
          if (!visited.Any(a => a.Key == top.Key && a.Value == top.Value))
          {
            visited.Add(new KeyValuePair<int, int>(top.Key, top.Value));
            CheckAndFlashe(stack, top.Key, top.Value);
          }
        }
      }
    }
    return energylevels;
  }


  static void Main(string[] args)
  {
    string[] lines = File.ReadAllLines(inputPath);

    foreach (string line in lines)
    {
      ++n;
      m = -1;
      foreach (char e in line)
      {
        ++m;
        energylevels[n, m] = int.Parse(e.ToString());
      }
    }

    int a = 0;
    while (!Check())
    {
      ++a;
      energylevels = Step();
      energylevels = Flashes();

    }
    System.Console.WriteLine(a);

  }
}