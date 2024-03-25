using System;


public class FileFormatting {
    public static long KeyPressCount(int[] spaces) {
        long keyPressCount = 0;
        foreach (var i in spaces) {
            keyPressCount += (i / 4) + Math.Min(i % 4, 2);
        }

        return keyPressCount;
    }
}

public class Program {
    static int GetInt() => int.Parse(Console.ReadLine());

    static void Main(string[] args) {
        int rows = GetInt();
        var spaces = new int[rows];
        for (int i = 0; i < rows; ++i) {
            spaces[i] = GetInt();
        }

        Console.WriteLine(FileFormatting.KeyPressCount(spaces));
    }
}