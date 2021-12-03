
class AdventOfCode2021
{
  public const string inputPath = @"C:\Users\Marina Rusu\source\repos\AdventOfCode2021\AdventOfCode2021\input.txt";
  public const string outputPath = @"C:\Users\Marina Rusu\source\repos\AdventOfCode2021\AdventOfCode2021\output.txt";
  
  static int count = 0;
  static int[] gammaZero = new int[20];
  static int[] gammaOne = new int[20];
  static void UpdateGamma(string[] lines)
  {
    gammaOne = new int[20];
    gammaZero = new int[20];
    foreach (string line in lines)
    {
      count = 0;
      foreach (char l in line)
      {
        if (line[count] == '0')
        {
          ++gammaZero[count];
        }
        else
        {
          ++gammaOne[count];
        }
        ++count;
      }
    }
  }

  static int[] BitsFromStringToInt(string bits)
  {
    int[] bitsResult = new int[20];
    int i = 0;
    foreach(char c in bits)
    {
      if(c == '0')
        bitsResult[i] = 0;
      else
        bitsResult[i] = 1;
      ++i;
    }
    return bitsResult;
  }

  static string CO2Generate(string[] lines)
  {
    UpdateGamma(lines);
    List<string> CO2ScrubberGenerator = new List<string>(lines);
    List<string> valuesToDelete = new List<string>();
    for (int i = 0; i < count; i++)
    {
      if (CO2ScrubberGenerator.Count < 2)
        break;
      UpdateGamma(CO2ScrubberGenerator.ToArray());
      valuesToDelete.Clear();
      foreach (var line in CO2ScrubberGenerator)
      {
        char keepBit = '0';
        if (gammaOne[i] < gammaZero[i])
          keepBit = '1';
        else
          keepBit = '0';
        var value = line[i];
        if (value != keepBit)
        {
          valuesToDelete.Add(line);
        }
      }

      foreach (var del in valuesToDelete)
      {
        CO2ScrubberGenerator.Remove(del);
      }
    }
    return CO2ScrubberGenerator[0];
  }

  static double ToBase10(int[] bits)
  {
    double gammaResz = 0;
    for (int i = 0; i < count; i++)
    {
      var a = Math.Pow(2, count - i - 1);
      gammaResz += a * bits[i];
    }
    return gammaResz;
  }

  static string OxygenGenerate(string[] lines)
  {
    UpdateGamma(lines);
    List<string> oxigenGenerators = new List<string>(lines);
    List<string> valuesToDelete = new List<string>();
    for (int i = 0; i < count; i++)
    {
      if (oxigenGenerators.Count < 2)
        break;
      UpdateGamma(oxigenGenerators.ToArray());
      valuesToDelete.Clear();
      foreach (var line in oxigenGenerators)
      {
        char keepBit = '0';
        if (gammaOne[i] >= gammaZero[i])
          keepBit = '1';
        else
          keepBit = '0';
        var value = line[i];
        if (value != keepBit)
        {
          valuesToDelete.Add(line);
        }
      }

      foreach (var del in valuesToDelete)
      {
        oxigenGenerators.Remove(del);
      }
    }
    return oxigenGenerators[0];
  }

  static void Main(string[] args)
  {
    
    string[] lines = File.ReadAllLines(inputPath);

   
    var oxygen = ToBase10(BitsFromStringToInt(OxygenGenerate(lines)));

    var co2 = ToBase10(BitsFromStringToInt(CO2Generate(lines)));

    Console.WriteLine("Result = {0}", oxygen * co2);
  }

}