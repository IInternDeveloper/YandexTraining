using System;
using System.Collections.Generic;
using System.Linq;

public class SetOperations {
    public static SortedSet<int> IntersertionLeastTwo(
        HashSet<int> A, HashSet<int> B, HashSet<int> C) {
        var result = new HashSet<int>(A);

        A.IntersectWith(B);
        B.IntersectWith(C);
        result.IntersectWith(C);

        B.UnionWith(A);
        result.UnionWith(B);

        return new SortedSet<int>(result);
    }
}

public class Program {
    static int[] Input() =>
        Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

    static void Main(string[] args) {
        const int setsCount = 3;
        var sets = new HashSet<int>[setsCount];

        int setSize = -1;
        for (int i = 0; i < setsCount; ++i) {
            setSize = int.Parse(Console.ReadLine());
            sets[i] = Input().ToHashSet<int>();
        }

        var result = SetOperations.IntersertionLeastTwo(sets[0], sets[1], sets[2]);
        foreach (var item in result) {
            Console.Write($"{item} ");
        }
    }
}