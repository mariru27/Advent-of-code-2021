
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

  static void printMatrix(int[,] mat)
  {
    for(int i = 0; i < 10; ++i)
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
    foreach (string line in lines)
    {
      var result = line.Split(",");
      foreach(var r in result)
      {
        fishList.Add(int.Parse(r));
      }
    }

    int count = 0;
    int nr = 16;
    for(int j = 0; j<80 ; ++j)
    {
      count = 0;
      nr = fishList.Count;
      for (int i = 0; i<nr;++i)
      {
        if(fishList[i] == 0)
        {
          fishList[i] = 6;
          //if(count == 0)
          //{
            fishList.Add(8);
          //  count++;
          //}
        }else
        {
          --fishList[i];
        }
      }
    }

    Console.WriteLine("Result= {0}", fishList.Count);
  }


}