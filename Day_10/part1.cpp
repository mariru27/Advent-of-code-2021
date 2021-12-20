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

    Dictionary<char, int> count = new() 
    { 
      {']', 0 },
      {')', 0 },
      {'}', 0 },
      {'>', 0 }
    };
    count[']'] = 0;
    foreach (string line in lines)
    {
      Stack<char> stack = new();
      char rememberC = ' ';
      foreach (char c in line)
      {
        if (c == '[' || c == '{' || c == '(' || c == '<')
          stack.Push(c);
        else
        {
          var first = stack.Pop();
          if (first == '[' && c != ']')
          {
            rememberC = c;
            ++count[c];
            break;
          }

          if (first == '(' && c != ')')
          {
            rememberC = c;
            ++count[c];
            break;
          }

          if (first == '{' && c != '}')
          {
            rememberC = c;
            ++count[c];
            break;
          }

          if (first == '<' && c != '>')
          {
            rememberC = c;
            ++count[c];
            break;
          }
        }
      }
    }
    Console.WriteLine((count[')']*3) + (count[']']*57) + (count['}'] * 1197) + (count['>']* 25137));
  }
}
