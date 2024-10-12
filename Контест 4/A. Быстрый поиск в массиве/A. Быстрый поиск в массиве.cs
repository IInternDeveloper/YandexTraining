using System;

public class NumsCounterInSegment {
    private int[] _nums;
    private int _numsCount;

    public NumsCounterInSegment(int[] nums, int numsCount) =>
        (_nums, _numsCount) = (nums, numsCount);

    public int Count(int L, int R) =>
        RBinarySearch(R) - LBinarySearch(L) + 1;

    private int LBinarySearch(int L) {
        int left = -1;
        int right = _numsCount;

        while (right - left > 1) {
            int mid = left + (right - left) / 2;
            if (_nums[mid] >= L) {
                right = mid;
            } else {
                left = mid;
            }
        }

        return right;
    }

    private int RBinarySearch(int R) {
        int left = -1;
        int right = _numsCount;

        while (right - left > 1) {
            int mid = left + (right - left) / 2;
            if (_nums[mid] <= R) {
                left = mid;
            } else {
                right = mid;
            }

        }

        return left;
    }
}

public class Program {
    static int[] Input() =>
        Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

    static void Main(string[] args) {
        int numsCount = int.Parse(Console.ReadLine());
        var nums = Input();
        Array.Sort(nums);

        var counter = new NumsCounterInSegment(nums, numsCount);

        int requestsCount = int.Parse(Console.ReadLine());
        var responses = new int[requestsCount];
        for (int i = 0; i < requestsCount; ++i) {
            var LR = Input();
            responses[i] = counter.Count(LR[0], LR[1]);
        }

        foreach (var response in responses) {
            Console.Write($"{response} ");
        }
    }
}