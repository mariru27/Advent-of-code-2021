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
    int[,] heightMap= new int[100, 100];
    int[,] minMap = new int[100, 100];
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
    List<KeyValuePair<int, int>> lowPointCoordonates = new List<KeyValuePair<int, int>>();

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
          lowPointCoordonates.Add(new KeyValuePair<int, int>(i, j));
          //Console.WriteLine("{0} {1} ", i, j);
        }
      }
    }

    int prod;
    List<int> bazins = new List<int>();
    foreach(var point in lowPointCoordonates)
    {
      int basinSize = 0;
      Stack<KeyValuePair<int,int>> stack = new Stack<KeyValuePair<int, int>>();
      stack.Push(point);
      ++basinSize;
      List<KeyValuePair<int, int>> visited = new List<KeyValuePair<int, int>>();
      visited.Add(point);
      List<int> vis = new List<int>();
      vis.Add(heightMap[point.Key, point.Value]);

      while(stack.Count > 0)
      {
        var top = stack.Pop();

        if (top.Key > 0 && (heightMap[top.Key - 1, top.Value] != 9) && 
          visited.Any(item => item.Key == top.Key - 1 && item.Value == top.Value) == false)
        {
          stack.Push(new KeyValuePair<int, int>(top.Key - 1, top.Value));
          visited.Add(new KeyValuePair<int, int>(top.Key - 1, top.Value));
          vis.Add(heightMap[top.Key - 1, top.Value]);
          ++basinSize;
        }
        if (top.Value > 0 && (heightMap[top.Key, top.Value - 1] != 9) && 
          visited.Any(item => item.Key == top.Key && item.Value == top.Value - 1) == false)
        {
          stack.Push(new KeyValuePair<int, int>(top.Key, top.Value - 1));
          visited.Add(new KeyValuePair<int, int>(top.Key, top.Value - 1));
          vis.Add(heightMap[top.Key, top.Value - 1]);
          ++basinSize;
        }
        if (top.Value < lines[top.Key].Length - 1 && (heightMap[top.Key, top.Value + 1] != 9) && 
          visited.Any(item => item.Key == top.Key && item.Value == top.Value + 1) == false)
        {
          stack.Push(new KeyValuePair<int, int>(top.Key, top.Value + 1));
          vis.Add(heightMap[top.Key, top.Value]);
          visited.Add(new KeyValuePair<int, int>(top.Key, top.Value + 1));
          ++basinSize;
        }
        if (top.Key < lines.Length - 1 && (heightMap[top.Key + 1, top.Value] != 9) && 
          visited.Any(item => item.Key == top.Key + 1 && item.Value == top.Value) == false)
        {
          stack.Push(new KeyValuePair<int, int> ( top.Key + 1, top.Value));
          visited.Add(new KeyValuePair<int, int>(top.Key + 1, top.Value));
          vis.Add(heightMap[top.Key + 1, top.Value]);
          ++basinSize;
        }

      }

      bazins.Add(basinSize);
    }

    bazins.Sort();

    Console.WriteLine("Result= {0}", bazins[bazins.Count - 1] * bazins[bazins.Count - 2] * bazins[bazins.Count - 3]);
  }
}
