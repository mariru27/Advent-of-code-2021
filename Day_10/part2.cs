using System;
using System.Collections.Generic;
using System.IO;

class AdventOfCode2021
{
  public const string inputPath = @"C:\Users\Marina\source\repos\AdventOfCode2021\AdventOfCode2021\input.txt";
  public const string outputPath = @"C:\Users\Marina Rusu\source\repos\AdventOfCode2021\AdventOfCode2021\output.txt";

  static void Main(string[] args)
  {
    string[] lines = File.ReadAllLines(inputPath);

    Dictionary<char, long> count = new() 
    { 
      {'(', 0 },
      {'[', 0 },
      {'{', 0 },
      {'<', 0 },
      {']', 0 },
      {')', 0 },
      {'}', 0 },
      {'>', 0 }
    };
    List<long> score = new();
    foreach (string line in lines)
    {
      Stack<char> stack = new();
      List<char> missingSequence = new();
      bool corrupted = false;
      foreach (char c in line)
      {

        if (c == '[' || c == '{' || c == '(' || c == '<')
        {
          stack.Push(c);
          ++count[c];
        }
        else
        {
          var first = stack.Pop();
          if (first == '[' && c != ']')
          {
            ++count[c];
            corrupted = true;
            missingSequence.Add(']');
            break;
          }

          if (first == '(' && c != ')')
          {
            ++count[c];
            corrupted = true;
            missingSequence.Add(')');
            break;
          }

          if (first == '{' && c != '}')
          {
            ++count[c];
            corrupted = true;
            missingSequence.Add('}');
            break;
          }

          if (first == '<' && c != '>')
          {
            ++count[c];
            corrupted = true;
            missingSequence.Add('>');
            break;
          }
        }
      }

      if (!corrupted)
      {
        long total = 0;
        foreach(var c in stack)
        {
          total *= 5;
          switch (c)
          {
            case '(': total += 1; break;
            case '[': total += 2; break;
            case '{': total += 3; break;
            case '<': total += 4; break;
            default:
              break;
          }
        }
        score.Add(total);
      }
    }
    score.Sort();
    Console.WriteLine(score[score.Count/2]);
  }
}
