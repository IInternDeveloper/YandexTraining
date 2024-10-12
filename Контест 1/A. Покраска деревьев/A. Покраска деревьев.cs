using System;
using static System.Math;

public class PaintingTrees {
    private Segment _A;
    private Segment _B;

    public PaintingTrees(Segment A, Segment B) =>
        (_A, _B) = (A.O < B.O) ? (A, B) : (B, A);

    public int Count() {
        if (_A.O + _A.R < _B.O - _B.R) {
            return 2 * (_A.R + _B.R + 1);
        }

        return Max(_A.O + _A.R, _B.O + _B.R) - Min(_A.O - _A.R, _B.O - _B.R) + 1;
    }
}

public struct Segment {
    public int O { get; set; }
    public int R { get; set; }

    public Segment(int O, int R) => (this.O, this.R) = (O, R);
}

public class Program {
    static int[] Input() =>
        Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

    static void Main(string[] args) {
        var segmentA = Input();
        var segmentB = Input();

        var A = new Segment(segmentA[0], segmentA[1]);
        var B = new Segment(segmentB[0], segmentB[1]);
        var paintingTrees = new PaintingTrees(A, B);

        Console.WriteLine(paintingTrees.Count());
    }
}