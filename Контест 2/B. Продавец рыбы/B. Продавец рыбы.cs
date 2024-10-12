using System;

public class FishSeller {
    public static int GetMaxProfit(int N, int K, int[] prices) {
        int maxProfit = 0;
        int currentProfit = 0;

        for (int delta = 1; delta <= K; ++delta) {
            for (int i = 0; i < N - delta; ++i) {
                currentProfit = prices[i + delta] - prices[i];
                if (currentProfit > maxProfit) {
                    maxProfit = currentProfit;
                }
            }
        }

        return maxProfit;
    }
}

public class Program {
    static int[] Input() =>
        Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

    static void Main(string[] args) {
        var NK = Input();
        var prices = Input();

        Console.WriteLine(
            FishSeller.GetMaxProfit(NK[0], NK[1], prices));
    }
}