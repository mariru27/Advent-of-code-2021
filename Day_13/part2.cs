using System.Diagnostics.CodeAnalysis;

class AdventOfCode2021
{
  public const string inputPath = @"C:\Users\Marina Rusu\source\repos\AdventOfCode2021\AdventOfCode2021\input.txt";
  public const string outputPath = @"C:\Users\Marina Rusu\source\repos\AdventOfCode2021\AdventOfCode2021\output.txt";

  static char[,] matrix = new char[10000, 10000];
  static void PrintMatrix(char[,] energylevels, int n, int m)
  {
    for (int i = 0; i <= n; i++)
    {
      for (int j = 0; j <= m; j++)
      {
        System.Console.Write("{0} ", energylevels[i, j]);
      }
      System.Console.WriteLine();
    }
    System.Console.WriteLine("--------------------------------------------------------------------------------");
  }

  class Point : IEqualityComparer<Point>
  {
    public int x;
    public int y;
    public Point(int xCoordonate = 0, int yCoordonate = 0)
    {
      x = xCoordonate;
      y = yCoordonate;
    }
    public static bool operator ==(Point a, Point b)
    => (a.x == b.x && a.y == b.y);

    public static bool operator !=(Point a, Point b)
    => !(a.x == b.x && a.y == b.y);

    public bool Equals(Point a, Point b)
    {
      return a == b;
    }

    public int GetHashCode([DisallowNull] Point obj)
    {
      throw new NotImplementedException();
    }
  }

  static List<Point> points = new List<Point>();
  static List<Point> foldPoints = new List<Point>();

  static Point GetMaximPoints(List<Point> points)
  {
    Point point = new();

    foreach (Point p in points)
    {
      point.x = Math.Max(point.x, p.x);
      point.y = Math.Max(point.y, p.y);
    }
    return point;
  }

  static void UpdateMatrix()
  {
    Point maximXYPoints = GetMaximPoints(points);
    for (int i = 0; i <= maximXYPoints.y; i++)
    {
      for (int j = 0; j <= maximXYPoints.x; j++)
      {
        matrix[i, j] = '.';
      }
    }

    foreach (Point p in points)
    {
      matrix[p.y, p.x] = '#';
    }
  }
  static void FoldPaperLeft(Point foldToPoint)
  {
    Point maximXYPoints = GetMaximPoints(points);
    for (int i = 0; i < points.Count; i++)
    {
      if (points[i].x > foldToPoint.x)
      {
        points[i].x = maximXYPoints.x - points[i].x;
      }
    }
    points = points
      .GroupBy(p => new { p.x, p.y })
      .Select(g => g.First())
      .ToList();
  }

  static void FoldPaperUp(Point foldToPoint)
  {
    Point maximXYPoints = GetMaximPoints(points);
    for (int i = 0; i < points.Count; i++)
    {
      if (points[i].y > foldToPoint.y)
      {
        points[i].y = maximXYPoints.y - points[i].y;
      }
    }
    points = points
      .GroupBy(p => new { p.x, p.y })
      .Select(g => g.First())
      .ToList();
  }

  static void FoldPaper()
  {
    foreach (Point foldToPoint in foldPoints)
    {
      if (foldToPoint.x == 0)
      {
        FoldPaperUp(foldToPoint);
        //UpdateMatrix();
        //Point maxims = GetMaximPoints(points);
        //PrintMatrix(matrix, maxims.y, maxims.x);
      }
      if (foldToPoint.y == 0)
      {
        FoldPaperLeft(foldToPoint);
        //UpdateMatrix();
        //Point maxims = GetMaximPoints(points);
        //PrintMatrix(matrix, maxims.y, maxims.x);
      }
    }
  }

  static void Main(string[] args)
  {
    string[] lines = File.ReadAllLines(inputPath);
    foreach (string line in lines)
    {
      if (line == "")
        continue;
      var result = line.Split(",");
      if (!line.Contains("fold"))
      {
        points.Add(new Point(int.Parse(result[0]), int.Parse(result[1])));
      }
      else
      {
        var res = line.Split("=");
        if (line.Contains("x"))
        {
          foldPoints.Add(new Point(int.Parse(res[1]), 0));
        }
        else
        {
          foldPoints.Add(new Point(0, int.Parse(res[1])));
        }
      }
    }
    FoldPaper();

    UpdateMatrix();
    Point maxims = GetMaximPoints(points);
    PrintMatrix(matrix, maxims.y, maxims.x);
    System.Console.WriteLine(points.Count);
  }
}