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
    int[] counts = new int[10];
    string[] digitRepresentation = new string[10] { "abcefg", "cf", "acdeg", "acdfg", "bcdf", "abdfg", "abdfeg", "acf", "abcdefg", "abcdfg" };
    foreach (string line in lines)
    {
      var result = line.Split(" | ");
      List<string> uniqueSignalPatterns = new List<string>(result[0].Split(" "));
      List<string> outputDigitValues = new List<string>(result[1].Split(" "));

      foreach(var digit in outputDigitValues)
      {
        if(digit.Length == digitRepresentation[1].Length)
        {
          ++counts[1];
        }
        if(digit.Length == digitRepresentation[4].Length)
        {
          ++counts[4];
        }
        if (digit.Length == digitRepresentation[7].Length)
        {
          ++counts[7];
        }
        if (digit.Length == digitRepresentation[8].Length)
        {
          ++counts[8];
        }
      }
    }
    var sum = counts.Aggregate((total, next) => total + next);
    Console.WriteLine("Result= {0}", sum);
  }


}