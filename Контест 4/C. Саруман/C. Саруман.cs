using System;


public class SarumansAttack {
    public static long SuitableRegimentIndex(long[] prefixes, long regiments, long orcs) {
        long left = -1;
        long right = prefixes.Length - regiments;

        while (right - left > 1) {
            long mid = left + (right - left) / 2;
            if (prefixes[mid + regiments] - prefixes[mid] <= orcs) {
                left = mid;
            } else {
                right = mid;
            }
        }

        bool hasRequiredRegiments = left == -1 ||
            prefixes[left + regiments] - prefixes[left] != orcs;

        return hasRequiredRegiments ? -1 : left + 1;
    }
}

public class Program {
    static long[] Input() =>
        Array.ConvertAll(Console.ReadLine().Split(), long.Parse);

    static void Main(string[] args) {
        var NM = Input();

        var orcsInRegiments = Input();
        var prefixes = new long[NM[0] + 1];
        prefixes[0] = 0;
        for (int i = 1; i < prefixes.Length; ++i) {
            prefixes[i] = prefixes[i - 1] + orcsInRegiments[i - 1];
        }

        var responses = new long[NM[1]];
        for (int i = 0; i < NM[1]; ++i) {
            var LS = Input();
            responses[i] = SarumansAttack.SuitableRegimentIndex(prefixes, LS[0], LS[1]);
        }

        foreach (var response in responses) {
            Console.WriteLine(response);
        }
    }
}