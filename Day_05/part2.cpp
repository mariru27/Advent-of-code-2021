
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


    int[,] submarineReview = new int[10000, 10000];
    foreach (string line in lines)
    {
      var result = line.Split(" -> ");
      var oneEnd = result[0].Split(",");
      var otherEnd = result[1].Split(",");
      if (int.Parse(oneEnd[0]) == int.Parse(otherEnd[0]))
      {
        var y1 = int.Parse(oneEnd[1]);
        var y2 = int.Parse(otherEnd[1]);
        if (y1 > y2)
          Swap(ref y1, ref y2);

        for (int i = y1; i <= y2; i++)
        {
          ++submarineReview[int.Parse(oneEnd[0]), i];
        }
        continue;
      }
      if (int.Parse(oneEnd[1]) == int.Parse(otherEnd[1]))
      {
        var x1 = int.Parse(oneEnd[0]);
        var x2 = int.Parse(otherEnd[0]);
        if (x1 > x2)
          Swap(ref x1, ref x2);
        for (int i = x1; i <= x2; i++)
        {
          ++submarineReview[i, int.Parse(oneEnd[1])];
        }
        continue;
      }

      var y11 = int.Parse(oneEnd[1]);
      var y22 = int.Parse(otherEnd[1]); 
      var x11 = int.Parse(oneEnd[0]);
      var x22 = int.Parse(otherEnd[0]);

      ++submarineReview[x11, y11];
      var n = Math.Abs(y11 - y22);
      for (int k = 0; k < n; k++)
      {
        if(y11 >= y22)
        {
          --y11;
        }else
        {
          ++y11;
        }
        
        if(x11 >= x22)
        {
          --x11;
        }
        else
        {
          ++x11;
        }

        ++submarineReview[x11, y11];
      }

    }

    int countOverlap = 0;
    for(int i = 0; i < 10000; i++)
    {
      for(int j = 0;j< 10000; j++)
      {
        if(submarineReview[i, j] >= 2)
        {
          ++countOverlap;
        }
      }
    }
    Console.WriteLine("Result= {0}", countOverlap);
  }


}