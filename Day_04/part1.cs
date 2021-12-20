
class AdventOfCode2021
{
  public const string inputPath = @"C:\Users\Marina Rusu\source\repos\AdventOfCode2021\AdventOfCode2021\input.txt";
  public const string outputPath = @"C:\Users\Marina Rusu\source\repos\AdventOfCode2021\AdventOfCode2021\output.txt";

  static void PlayBingo_Part1(List<Dictionary<int, int>[,]> boards, List<int> numbers)
  {
    int[] markedRows = new int[10000];
    int[,] markedColumns = new int[10000,5];
    int rowValue = 0;
    int columnValue = 0;
    bool bingo = false;
    int s;
    for (s = 0; s < numbers.Count; ++s)
    {
      for (int i = 0; i < boards.Count; ++i)
      {
        for (int j = 0; j < 5; ++j)
        {
          for (int l = 0; l < 5; ++l)
          {
            if (boards[i][j, l].ContainsKey(numbers[s]))
            {
              var row = boards[i][j, l][numbers[s]];
              ++markedRows[row];
              ++markedColumns[(row) / 5, l];
              if (markedRows[row] == 5 || markedColumns[(row) / 5, l] == 5)
              {
                rowValue = row;
                columnValue = l;
                bingo = true;
                break;
              }
            }
          }
          if (bingo)
            break;
        }
      }
      if(bingo)
        break;
    }

    int sum = 0;
    var index = ((rowValue) / 5);

    var board = boards[index];
    for(var i = 0; i < 5; ++i)
    {
      for(var j = 0; j < 5; ++j)
      {
        bool foundNr = false;
        var key = board[i,j].Keys.FirstOrDefault();
        for(int l = 0; l <= s; ++l)
        {
          if(key == numbers[l])
          {
            foundNr = true;
            break;
          }
        }
          if(foundNr == false)
        {
          sum += key;
        }  
      }
    }
    var result = numbers[s] * sum;
    Console.WriteLine("Result part1 = {0}", result);

  }

  static void Main(string[] args)
  {
    
    string[] lines = File.ReadAllLines(inputPath);
    List<Dictionary<int,int>[,]> boards = new();
    List<int> numbers = new();
    int row = 0;
    //read numbers
    var result = lines[0].Split(',');
    foreach (string i in result)
    {
      numbers.Add(int.Parse(i));
    }

    //read boards
    for(int k = 1; k < lines.Length; k++)
    {
      Dictionary<int, int>[,] board = new Dictionary<int, int>[10, 10];
      if (lines[k].Length < 5)
        continue;
      for(int i = 0; i< 5; i++)
      {
        if (lines[k + i][0].ToString() == " ")
        {
          lines[k + i] = lines[k+i].Remove(0, 1);
        }
        var values = lines[k+i].Replace("  ", " ").Split(' ');
        int count = 5;
      
        for (int j = 0; j < count; j++)
        {
          var pair = new Dictionary<int, int>
          {
            { int.Parse(values[j]), row }
          };
          board[i, j]= pair;
        }
          ++row;
      }
      k += 5;
       boards.Add(board);
    }

    PlayBingo_Part1(boards,numbers);
  }

}