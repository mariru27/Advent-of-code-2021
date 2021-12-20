
using System;
using System.Collections.Generic;
using System.IO;

class AdventOfCode2021
{
  public const string inputPath = @"C:\Users\Marina\source\repos\AdventOfCode2021\AdventOfCode2021\input.txt";
  public const string outputPath = @"C:\Users\Marina Rusu\source\repos\AdventOfCode2021\AdventOfCode2021\output.txt";

  static void Swap(ref int x, ref int y)
  {

    int tempswap = x;
    x = y;
    y = tempswap;
  }

  static void printMatrix(int[,] mat)
  {
    for (int i = 0; i < 10; ++i)
    {
      for (int j = 0; j < 10; ++j)
      {
        Console.Write(string.Format("{0} ", mat[i, j]));

      }
      Console.Write(Environment.NewLine + Environment.NewLine);
    }
  }
  static void Main(string[] args)
  {

    string[] lines = File.ReadAllLines(inputPath);

    List<int> fishList = new List<int>();
    Dictionary<long, long> fishl = new Dictionary<long, long>();
    foreach (string line in lines)
    {
      var result = line.Split(",");
      foreach (var r in result)
      {
        fishList.Add(int.Parse(r));
        if (!fishl.ContainsKey(int.Parse(r)))
          fishl.Add(int.Parse(r), 0);
        ++fishl[int.Parse(r)];
      }
    }

    for (int j = 0; j < 256; ++j)
    {
      Dictionary<long, long> tempList = new Dictionary<long, long>(fishl);
      foreach (KeyValuePair<long, long> entry in tempList)
      {
        if (entry.Key == 0)
        {
          if (fishl.ContainsKey(entry.Key) && tempList[entry.Key] > 0)
          {
            fishl[entry.Key] -= tempList[entry.Key];
          }

          if (!tempList.ContainsKey(6))
            fishl.Add(6, 0);
          fishl[6] += tempList[entry.Key];

          if (!tempList.ContainsKey(8))
          {
            fishl.Add(8, 0);
          }
          fishl[8] += tempList[entry.Key];
        }
        else
        {
          if (fishl.ContainsKey(entry.Key))
          {
            if (!fishl.ContainsKey(entry.Key - 1))
              fishl.Add(entry.Key - 1, 0);
            fishl[entry.Key - 1] += tempList[entry.Key];

            if (tempList[entry.Key] > 0)
              fishl[entry.Key] -= tempList[entry.Key];
          }
        }
      }
    }

    long total = 0;
    foreach(var fish in fishl)
    {
      total += fish.Value;
    }
    Console.WriteLine("Result= {0}", total);
  }


}