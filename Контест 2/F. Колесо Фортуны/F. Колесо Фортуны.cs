using System;
using static System.Math;


public class FortunesWheel {
    public static int GetMaxPoint(int[] points, int N, int A, int B, int K) {
        int maxPoint = -1;

        int minIndex = GetIndex(A, K);
        int maxIndex = GetIndex(B, K);

        if (maxIndex - minIndex >= N - 1) {
            maxIndex = minIndex + N - 1;
        }

        for (int i = minIndex; i <= maxIndex; ++i) {
            maxPoint = Max(maxPoint,
                Max(points[i % N], points[(N - i % N) % N]));
        }

        return maxPoint;
    }

    private static int GetIndex(int speed, int K) =>
        speed / K + (speed % K == 0 ? -1 : 0);
}

public class Program {
    static int[] Input() =>
        Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

    static void Main(string[] args) {
        int pointsCount = int.Parse(Console.ReadLine());
        var points = Input();
        var ABK = Input();

        Console.WriteLine(
            FortunesWheel.GetMaxPoint(points, pointsCount, ABK[0], ABK[1], ABK[2]));
    }
}