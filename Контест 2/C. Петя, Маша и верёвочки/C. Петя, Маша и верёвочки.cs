using System;

public class Ropes {
    public static int MinPossibleLength(int[] ropes, int ropesCount) {
        int largestRope = ropes[0];
        int partSum = 0;
        for (int i = 1; i < ropesCount; ++i) {
            if (ropes[i] > largestRope) {
                partSum += largestRope;
                largestRope = ropes[i];
            } else {
                partSum += ropes[i];
            }
        }

        return MinPossibleLength(largestRope, partSum);
    }

    private static int MinPossibleLength(int largestRope, int partSum) =>
        largestRope + (largestRope <= partSum ? partSum : -partSum);
}

public class Program {
    static int[] Input() =>
        Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

    static void Main(string[] args) {
        int ropesCount = int.Parse(Console.ReadLine());
        var ropes = Input();

        Console.WriteLine(Ropes.MinPossibleLength(ropes, ropesCount));
    }
}