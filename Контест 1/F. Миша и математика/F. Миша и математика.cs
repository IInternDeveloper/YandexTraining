using System;


public class MishaAndMath {
    public static string GetOperators(int[] nums, int numsCount) {
        int operatorsCount = numsCount - 1;
        var operators = new char[operatorsCount];

        int result = nums[0];
        for (int i = 0; i < operatorsCount; ++i) {
            (result, operators[i]) = GetOperator(result, nums[i + 1]);
        }

        return new string(operators);
    }

    private static (int, char) GetOperator(int X, int Y) {
        if (X % 2 != 0 && Y % 2 != 0) {
            return (1, 'x');
        }
        if ((X + Y) % 2 != 0) {
            return (1, '+');
        }

        return (0, '+');
    }
}

public class Program {
    static int[] Input() =>
        Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

    static void Main(string[] args) {
        int numsCount = int.Parse(Console.ReadLine());
        var nums = Input();

        Console.WriteLine(MishaAndMath.GetOperators(nums, numsCount));
    }
}