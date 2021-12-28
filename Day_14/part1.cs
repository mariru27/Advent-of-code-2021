using System.Collections.Generic;
using System.IO;
using System.Linq;

class AdventOfCode2021
{
  public const string inputPath = @"C:\Users\Marina\source\repos\AdventOfCode2021\AdventOfCode2021\input.txt";
  public const string outputPath = @"C:\Users\Marina Rusu\source\repos\AdventOfCode2021\AdventOfCode2021\output.txt";

  static string[] lines = File.ReadAllLines(inputPath);
  static Dictionary<string, string> rules = new();
  static string polymer = string.Empty;

  static void InsertPairs()
  {
    for (int k = 0; k < 10; ++k)
    {
      string tempPolymer = new string(polymer);

      for (int i = 1, j = 1; i < polymer.Length; ++i, ++j)
      {
        string pair = polymer[i - 1].ToString() + polymer[i].ToString();
        if (rules.ContainsKey(pair))
        {
          tempPolymer = tempPolymer.Insert(j, rules[pair]);
          ++j;
        }
      }
      polymer = tempPolymer;
    }

    Dictionary<char, int> count = new();

    foreach(var p in polymer)
    {
      if (!count.ContainsKey(p))
      {
        count.Add(p, 1);
      }
      else
      {
        ++count[p];
      }
    }

    int min = count.Select(a => a.Value).ToList().Min();
    int max = count.Select(a => a.Value).ToList().Max();
    System.Console.WriteLine(max - min);
  }

  static void Main(string[] args)
  {
    polymer = lines[0];
    for (int i = 2; i < lines.Length; ++i)
    {
      var result = lines[i].Split(" -> ");
      rules.Add(result[0], result[1]);
    }

    InsertPairs();

  }
}