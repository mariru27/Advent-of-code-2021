
class AdventOfCode2021
{
  public const string inputPath = @"C:\Users\Marina Rusu\source\repos\AdventOfCode2021\AdventOfCode2021\input.txt";
  public const string outputPath = @"C:\Users\Marina Rusu\source\repos\AdventOfCode2021\AdventOfCode2021\output.txt";
  static void Main(string[] args)
  {
    int incNr = 0;
    string[] lines = File.ReadAllLines(inputPath);
    int addNr = 0;
    int sum = 0;
    List<int> sums = new List<int>();
    int[] sums2 = new int[10000];
    foreach(var line in lines)
    {
      if (addNr == 3)
      {
        sum = 0;
      }
      sums2[addNr] += int.Parse(line);
      sums2[addNr + 1] += int.Parse(line);
      sums2[addNr + 2] += int.Parse(line);
      ++addNr;
    }
    var num = sums2[2];
    for(int j = 3; j < addNr; j++)
    {
      if(sums2[j] > num)
      {
        ++incNr;
      }
      num = sums2[j];
    }
    Console.WriteLine("Result = {0}", incNr);
  }
}