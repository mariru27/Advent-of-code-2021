
class AdventOfCode2021
{
  public const string inputPath = @"C:\Users\Marina Rusu\source\repos\AdventOfCode2021\AdventOfCode2021\input.txt";
  public const string outputPath = @"C:\Users\Marina Rusu\source\repos\AdventOfCode2021\AdventOfCode2021\output.txt";

  static void Main(string[] args)
  {
    string[] lines = File.ReadAllLines(inputPath);
    int horizontalPozition = 0;
    int depth = 0;
    foreach (var line in lines)
    {
      string[] result = line.Split(" ");
      int value = int.Parse(result[1]);
      switch (result[0])
      {
        case "forward":
          horizontalPozition += value; break;
        case "down":
          depth += value; break;
        case "up":
          depth -= value; break;
        default:
          break;
      }
    }
   
    Console.WriteLine("Result = {0}", horizontalPozition * depth);
  }

}