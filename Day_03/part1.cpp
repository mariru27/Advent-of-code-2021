
class AdventOfCode2021
{
  public const string inputPath = @"C:\Users\Marina Rusu\source\repos\AdventOfCode2021\AdventOfCode2021\input.txt";
  public const string outputPath = @"C:\Users\Marina Rusu\source\repos\AdventOfCode2021\AdventOfCode2021\output.txt";

  static void Main(string[] args)
  {
    string[] lines = File.ReadAllLines(inputPath);
    int[] gammaZero = new int[20];
    int[] gammaOne = new int[20];
    int count = 0;
    foreach (string line in lines)
    {
      count = 0;
      foreach(char l in line)
      {
        if(line[count] == '0')
        {
          ++gammaZero[count];
        }else
        {
          ++gammaOne[count];
        }
        ++count;
      }
    }

    int[] gamma = new int[20];
    int[] epsilon = new int[20];
    for(int i = 0; i < count; i++)
    {
      if (gammaOne[i] > gammaZero[i])
        gamma[i] = 1;
      else
        gamma[i] = 0;

      if (gammaOne[i] < gammaZero[i])
        epsilon[i] = 1;
      else
        epsilon[i] = 0;
    }

    double gammaResz = 0;
    double epsilonResz = 0;
    for (int i = 0; i < count; i++)
    {
      var a = Math.Pow(2, count - i - 1);
      gammaResz += a*gamma[i];
      epsilonResz += a*epsilon[i];
    }

    Console.WriteLine("Result = {0}", gammaResz * epsilonResz);
  }

}