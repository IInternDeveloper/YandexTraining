using System;
using System.Collections.Generic;


public class RemovingNums {
    private int[] _nums;

    private int _numsCount;

    private Dictionary<int, int> _numsCounter;

    public RemovingNums(int[] nums, int numsCount) {
        (_nums, _numsCount) = (nums, numsCount);
        _numsCounter = NumsCounter(nums);
    }

    public int MinCountRemovedNums() {
        int maxCountNeighbors = 0;

        (int min, int max) = GetMinMax();
        for (int num = min; num <= max; ++num) {
            maxCountNeighbors = Math.Max(
                maxCountNeighbors, Count(num) + Count(num + 1));
        }

        return _numsCount - maxCountNeighbors;
    }

    private Dictionary<int, int> NumsCounter(int[] nums) {
        var numsCounter = new Dictionary<int, int>();
        foreach (var num in nums) {
            if (!numsCounter.ContainsKey(num)) {
                numsCounter[num] = 0;
            }
            numsCounter[num]++;
        }

        return numsCounter;
    }

    private (int, int) GetMinMax() {
        int min = _nums[0];
        int max = _nums[0];
        foreach (var num in _nums) {
            if (num < min) {
                min = num;
            }
            if (num > max) {
                max = num;
            }
        }

        return (min, max);
    }

    private int Count(int num) =>
        _numsCounter.ContainsKey(num) ? _numsCounter[num] : 0;
}

public class Program {
    static int[] Input() =>
        Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

    static void Main(string[] args) {
        int numsCount = int.Parse(Console.ReadLine());
        var nums = Input();

        var removingNums = new RemovingNums(nums, numsCount);

        Console.WriteLine(removingNums.MinCountRemovedNums());
    }
}