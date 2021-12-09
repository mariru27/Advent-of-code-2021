using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class AdventOfCode2021
{
  public const string inputPath = @"C:\Users\Marina\source\repos\AdventOfCode2021\AdventOfCode2021\input.txt";
  public const string outputPath = @"C:\Users\Marina Rusu\source\repos\AdventOfCode2021\AdventOfCode2021\output.txt";

  

  static void Main(string[] args)
  {
    string[] lines = File.ReadAllLines(inputPath);
    int[,] heightMap= new int[10000, 10000];
    int[,] minMap = new int[10000, 10000];
    for(int i = 0; i <lines.Length; i++)
    {
      for(int j = 0; j < lines[i].Length; j++)
      {
        heightMap[i,j] = int.Parse(lines[i][j].ToString());
      }
    }

    for (int i = 0; i < lines.Length; i++)
    {
      for (int j = 0; j < lines[i].Length; j++)
      {
        List<int> locations = new List<int> { heightMap[i, j] };
        if(i > 0)
        {
          locations.Add(heightMap[i - 1, j]);
        }
        if(j > 0)
        {
          locations.Add(heightMap[i, j - 1]);
        }
        if (j < lines[i].Length - 1)
        {
          locations.Add(heightMap[i, j + 1]);
        }
        if (i < lines.Length - 1)
        {
          locations.Add(heightMap[i + 1, j]);
        }
        int min = locations.Min();
        minMap[i,j] = min;
      }
    }

    List<int> lowPoints = new List<int>();
    for (int i = 0; i < lines.Length; i++)
    {
      for (int j = 0; j < lines[i].Length; j++)
      {
        List<int> mins = new List<int> { minMap[i, j] };
        int count = 0;
        if (i > 0)
        {
          mins.Add(minMap[i - 1, j]);
        }
        if (j > 0)
        {
          mins.Add(minMap[i, j - 1]);
        }
        if (j < lines[i].Length - 1)
        {
          mins.Add(minMap[i, j + 1]);
        }
        if (i < lines.Length - 1)
        {
          mins.Add(minMap[i + 1, j]);
        }
        var a = mins.Where(min => min == mins[0]).Count();
        if(a == mins.Count)
        {
          lowPoints.Add(mins.First() + 1);
        }
      }
    }
    Console.WriteLine("Result= {0}", lowPoints.Sum());
  }
}
