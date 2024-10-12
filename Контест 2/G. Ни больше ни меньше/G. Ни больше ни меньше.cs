using System;
using System.Collections.Generic;

public class Partition {
    public static List<int> MinPartition(int[] nums, int numsCount) {
        var partition = new List<int>();

        (int length, int min) = (0, -1);
        for (int i = 0; i < numsCount;) {
            length++;
            if (min == -1 || min > nums[i]) {
                min = nums[i];
            }

            if (min >= length) {
                i++;
            } else {
                partition.Add(--length);
                (length, min) = (0, -1);
            }
        }
        partition.Add(length);

        return partition;
    }
}

public class Program {
    static int[] Input() =>
        Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

    static void Main(string[] args) {
        int requestsCount = int.Parse(Console.ReadLine());

        int numsCount = -1;
        var partitions = new List<int>[requestsCount];
        for (int i = 0; i < requestsCount; ++i) {
            numsCount = int.Parse(Console.ReadLine());
            var nums = Input();
            partitions[i] = Partition.MinPartition(nums, numsCount);
        }

        foreach (var partition in partitions) {
            Console.WriteLine(partition.Count);
            foreach (var length in partition) {
                Console.Write($"{length} ");
            }
            Console.WriteLine();
        }
    }
}