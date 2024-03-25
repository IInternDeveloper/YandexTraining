using System;
using System.Text;


public class ProfitableStartup {
    private static readonly int[] _digits = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

    public static string GetProfit(int N, int K, int D) {
        var profit = new StringBuilder(N.ToString());

        string firstDigit = FindMatchingDigit(N, K);
        if (firstDigit == String.Empty) {
            return "-1";
        }

        profit.Append(firstDigit);
        for (int day = 2; day <= D; ++day) {
            profit.Append(FindMatchingDigit(K));
        }

        return profit.ToString();
    }

    private static string FindMatchingDigit(int N, int K) {
        for (int i = 0; i < _digits.Length; ++i) {
            if ((10 * N + _digits[i]) % K == 0) {
                return _digits[i].ToString();
            }
        }

        return String.Empty;
    }

    private static string FindMatchingDigit(int K) {
        for (int i = 1; i < _digits.Length; ++i) {
            if (_digits[i] % K == 0) {
                return _digits[i].ToString();
            }
        }

        return "0";
    }
}

public class Program {
    static int[] Input() =>
        Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

    static void Main(string[] args) {
        var NKD = Input();

        Console.WriteLine(
            ProfitableStartup.GetProfit(NKD[0], NKD[1], NKD[2]));
    }
}