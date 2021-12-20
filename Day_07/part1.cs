
class AdventOfCode2021
{
  public const string inputPath = @"C:\Users\Marina Rusu\source\repos\AdventOfCode2021\AdventOfCode2021\input.txt";
  public const string outputPath = @"C:\Users\Marina Rusu\source\repos\AdventOfCode2021\AdventOfCode2021\output.txt";

  static void Swap(ref int x, ref int y)
  {

    int tempswap = x;
    x = y;
    y = tempswap;
  }
  static void Main(string[] args)
  {

    string[] lines = File.ReadAllLines(inputPath);

    List<int> horizontalPositions = new List<int>();
    Dictionary<int,int> fishl = new Dictionary<int,int>();

    var result = lines[0].Split(",");
    foreach(string r in result)
    {
      horizontalPositions.Add(int.Parse(r));
    }
    
    int minimCost = 10000000;

    for(int i = 0; i < horizontalPositions.Count; i++)
    {
      int cost = 0;
      for(int j = 0; j < horizontalPositions.Count; j++)
      {
        cost += Math.Abs(horizontalPositions[j] - horizontalPositions[i]);
      }
      if(minimCost > cost)
        minimCost = cost;
    }




    Console.WriteLine("Result= {0}", minimCost);
  }


}