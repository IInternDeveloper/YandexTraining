using System;

public class SeaBattle {
    public static long MaxPossibleK(long cellsCount) {
        long left = -1;
        long right = cellsCount + 1;

        while (right - left > 1) {
            long mid = left + (right - left) / 2;
            if (CanArrangeShips(mid, cellsCount)) {
                left = mid;
            } else {
                right = mid;
            }
        }

        return left;
    }

    private static bool CanArrangeShips(long K, long cellsCount) {
        long cellsForShips = -1;
        try {
            cellsForShips = checked(K * (K + 1) * (K + 5)) / 6 - 1;
        } catch (OverflowException) {
            return false;
        }

        return cellsForShips <= cellsCount;
    }
}

public class Program {
    static void Main(string[] args) {
        long cellsCount = long.Parse(Console.ReadLine());

        Console.WriteLine(
            SeaBattle.MaxPossibleK(cellsCount));
    }
}