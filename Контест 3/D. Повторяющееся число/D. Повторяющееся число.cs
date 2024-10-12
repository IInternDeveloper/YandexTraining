using System;
using System.Collections.Generic;

public class RepeatingNum {
    public static bool IsRepeating(int[] nums, int numsCount, int distance) {
        var previousNums = new HashSet<int>();
        for (int i = 0; i < numsCount; ++i) {
            if (previousNums.Contains(nums[i])) {
                return true;
            }
            
            previousNums.Add(nums[i]);
            if (i >= distance) {
                previousNums.Remove(nums[i - distance]);
            }
        }

        return false;
    }
}

public class Program {
    static int[] Input() =>
        Array.ConvertAll(Console.ReadLine().Trim().Split(), int.Parse);

    static void Main(string[] args) {
        var NK = Input();
        var nums = Input();

        Console.WriteLine(
            RepeatingNum.IsRepeating(nums, NK[0], NK[1]) ? "YES" : "NO");
    }
}