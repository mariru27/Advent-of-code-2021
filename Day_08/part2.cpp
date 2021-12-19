class AdventOfCode2021
{
  public const string inputPath = @"C:\Users\Marina Rusu\source\repos\AdventOfCode2021\AdventOfCode2021\input.txt";
  public const string outputPath = @"C:\Users\Marina Rusu\source\repos\AdventOfCode2021\AdventOfCode2021\output.txt";

  static int GetNumbers(string[] digitRepresentation, List<string> outputDigitValues, Dictionary<char, char> resultLetter)
  {
    int number = 0;
    foreach (var digitVal in outputDigitValues)
    {
      List<char> strNumber = new();
      foreach (var d in digitVal)
      {
        strNumber.Add(resultLetter[d]);
      }
      for (int i = 0; i < digitRepresentation.Length; ++i)
      {
        if (digitRepresentation[i].Length == strNumber.Count && digitRepresentation[i].ToCharArray().Intersect(strNumber).Count() == digitRepresentation[i].Length)
        {
          number = (number * 10) + i;
          break;
        }
      }
    }
    return number;
  }

  static void Main(string[] args)
  {

    string[] lines = File.ReadAllLines(inputPath);
    string[] digitRepresentation = new string[10] { "abcefg", "cf", "acdeg", "acdfg", "bcdf", "abdfg", "abdfeg", "acf", "abcdefg", "abcdfg" };
    List<int> counts = new();
    string[] numbers = new string[10];
    foreach (string line in lines)
    {
      Dictionary<char, char> resultLetter = new();
      var result = line.Split(" | ");
      List<string> uniqueSignalPatterns = new(result[0].Split(" "));
      List<string> outputDigitValues = new(result[1].Split(" "));

      //get number 1
      var nr1 = uniqueSignalPatterns.Where(a => a.Length == digitRepresentation[1].Length).FirstOrDefault();

      //get number 4
      var nr4 = uniqueSignalPatterns.Where(a => a.Length == digitRepresentation[4].Length).FirstOrDefault();

      //get number 7
      var nr7 = uniqueSignalPatterns.Where(a => a.Length == digitRepresentation[7].Length).FirstOrDefault();

      //get number 8
      var nr8 = uniqueSignalPatterns.Where(a => a.Length == digitRepresentation[8].Length).FirstOrDefault();

      //get all numbers that have length 5
      var length5 = uniqueSignalPatterns.Where(a => a.Length == digitRepresentation[2].Length).ToList();

      //get all numbers that have length 6
      var length6 = uniqueSignalPatterns.Where(a => a.Length == digitRepresentation[0].Length).ToList();

      //get a
      {
        var temp = nr7.ToCharArray().Except(nr1.ToCharArray()).ToArray();
        resultLetter['a'] = temp.First();
      }

      {
        //get c
        var temp5 = nr1.ToCharArray().Except(length6[0].ToCharArray()).ToArray();
        var temp6 = nr1.ToCharArray().Except(length6[1].ToCharArray()).ToArray();
        var temp7 = nr1.ToCharArray().Except(length6[2].ToCharArray()).ToArray();
        var c = temp5.Union(temp6.Union(temp7)).ToArray();
        resultLetter['c'] = c.First();

        //get d
        var temp1 = nr4.ToCharArray().Except(length6[0].ToCharArray()).ToArray();
        var temp2 = nr4.ToCharArray().Except(length6[1].ToCharArray()).ToArray();
        var temp3 = nr4.ToCharArray().Except(length6[2].ToCharArray()).ToArray();
        var tempR = temp1.Union(temp2.Union(temp3)).ToArray();
        resultLetter['d'] = temp1.Union(temp2.Union(temp3)).ToArray().Except(c).FirstOrDefault();
      }

      //get f
      {
        var temp1 = nr1.ToCharArray().Except(length5[0].ToCharArray()).ToArray();
        var temp2 = nr1.ToCharArray().Except(length5[1].ToCharArray()).ToArray();
        var temp3 = nr1.ToCharArray().Except(length5[2].ToCharArray()).ToArray();
        resultLetter['f'] = temp1.Union(temp2.Union(temp3)).ToArray().Except(new char[] { resultLetter['c'] }).FirstOrDefault();
      }

      //get b
      {
        var temp1 = nr4.ToCharArray().Except(length5[0].ToCharArray()).ToArray();
        var temp2 = nr4.ToCharArray().Except(length5[1].ToCharArray()).ToArray();
        var temp3 = nr4.ToCharArray().Except(length5[2].ToCharArray()).ToArray();

        var temp5 = temp1.Concat(temp2.Concat(temp3)).ToList();
        var distinctItems =
        from list in temp5
        group list by list into grouped
        where grouped.Count() > 1
        select grouped;
        resultLetter['b'] = distinctItems.First().Key;
      }


      {
        //get g
        var exceptLetter = new List<char>();
        foreach (var res in resultLetter)
        {
          exceptLetter.Add(res.Value);
        }

        var temp1 = length5[0].ToCharArray().Except(exceptLetter.ToArray()).ToArray();
        var temp2 = length5[1].ToCharArray().Except(exceptLetter.ToArray()).ToArray();
        var temp3 = length5[2].ToCharArray().Except(exceptLetter.ToArray()).ToArray();

        var temp5 = temp1.Concat(temp2.Concat(temp3)).ToList();
        var distinctItems =
        from list in temp5
        group list by list into grouped
        where grouped.Count() > 1
        select grouped;
        resultLetter['g'] = distinctItems.First().Key;

        //get e
        resultLetter['e'] = temp5.Select(x => x).Distinct().ToList().Except(new char[] { resultLetter['g'] }).FirstOrDefault();
      }

      Dictionary<char, char> resultLetterReversed = new();
      foreach (var res in resultLetter)
      {
        resultLetterReversed[res.Value] = res.Key;
      }

      counts.Add(GetNumbers(digitRepresentation, outputDigitValues, resultLetterReversed));
    }
    var sum = counts.Aggregate((total, next) => total + next);
    Console.WriteLine("Result= {0}", sum);
  }


}