using System;


public class CantorsTable {
    public static (long, long) GetFraction(long N) {
        long diagonal = GetDiagonal(N);

        long numerator = N - diagonal * (diagonal - 1) / 2;
        long denominator = (diagonal + 1) - numerator;

        if (diagonal % 2 == 0) {
            (numerator, denominator) = (denominator, numerator);
        }

        return (numerator, denominator);
    }

    private static long GetDiagonal(long N) {
        long left = 1;
        long right = N;

        while (right - left > 1) {
            long mid = left + (right - left) / 2;
            if (IsSuitableDiagonal(mid, N)) {
                right = mid;
            } else {
                left = mid;
            }
        }

        return right;
    }

    private static bool IsSuitableDiagonal(long K, long N) {
        long elementsCount = -1;
        try {
            elementsCount = checked(K * (K + 1) / 2);
        } catch {
            return true;
        }

        return elementsCount >= N;
    }
}

public class Program {
    static void Main(string[] args) {
        long N = long.Parse(Console.ReadLine());

        (long numerator, long denominator) = CantorsTable.GetFraction(N);

        Console.WriteLine($"{numerator}/{denominator}");
    }
}