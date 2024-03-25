using System;


public class FootballCommentator {
    public static int GetRequiredGoals(Match A, Match B, int locationStatus) {
        int delta = A.Y + B.Y - A.X - B.X;

        if (delta >= 0) {
            if (locationStatus == 1 && B.X + delta > A.Y) {
                return delta;
            }
            if (locationStatus == 2 && A.X > B.Y) {
                return delta;
            }
        }

        return delta < 0 ? 0 : delta + 1;
    }
}

public struct Match {
    public int X { get; set; }

    public int Y { get; set; }

    public Match(int X, int Y) => (this.X, this.Y) = (X, Y);
}

public class Program {
    static int[] Input() =>
        Array.ConvertAll(Console.ReadLine().Split(':'), int.Parse);

    static void Main(string[] args) {
        var matchA = Input();
        var matchB = Input();

        var A = new Match(matchA[0], matchA[1]);
        var B = new Match(matchB[0], matchB[1]);

        int locationStatus = int.Parse(Console.ReadLine());

        Console.WriteLine(
            FootballCommentator.GetRequiredGoals(A, B, locationStatus));
    }
}