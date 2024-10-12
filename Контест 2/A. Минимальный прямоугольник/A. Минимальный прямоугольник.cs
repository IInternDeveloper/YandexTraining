using System;

public class MinRectangle {
    public static (Point, Point) GetCoverage(Point[] points) =>
        (BottomLeft(points), TopRight(points));

    private static Point BottomLeft(Point[] points) {
        var bottomLeft = points[0];
        foreach (var point in points) {
            if (point.X < bottomLeft.X) {
                bottomLeft.X = point.X;
            }
            
            if (point.Y < bottomLeft.Y) {
                bottomLeft.Y = point.Y;
            }
        }

        return bottomLeft;
    }

    private static Point TopRight(Point[] points) {
        var topRight = points[0];
        foreach (var point in points) {
            if (point.X > topRight.X) {
                topRight.X = point.X;
            }

            if (point.Y > topRight.Y) {
                topRight.Y = point.Y;
            }
        }

        return topRight;
    }
}

public struct Point {
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int[] points) =>
        (this.X, this.Y) = (points[0], points[1]);
}

public class Program {
    static int[] Input() =>
        Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

    static void Main(string[] args) {
        int pointsCount = int.Parse(Console.ReadLine());
        var points = new Point[pointsCount];

        for (int i = 0; i < pointsCount; ++i) {
            points[i] = new Point(Input());
        }

        (Point bottomLeft, Point topRight) = MinRectangle.GetCoverage(points);

        Console.WriteLine(
            $"{bottomLeft.X} {bottomLeft.Y} {topRight.X} {topRight.Y}");
    }
}