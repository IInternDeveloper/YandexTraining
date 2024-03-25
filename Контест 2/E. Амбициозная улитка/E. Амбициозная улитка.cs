using System;
using System.Collections.Generic;


public class AmbitiousSnail {
    private Berry[] _berries;

    private int _berriesCount;

    public AmbitiousSnail(Berry[] berries, int berriesCount) =>
        (_berries, _berriesCount) = (berries, berriesCount);

    public (long, List<int>) GetAnswer() {
        var positive = new List<int>(GetPositive());
        var negative = new List<int>(GetNegative());

        return (MaxHeight(positive, negative), Combine(positive, negative));
    }

    private long MaxHeight(List<int> positive, List<int> negative) {
        long largestHeight = 0;
        foreach (var i in positive) {
            largestHeight += _berries[i].Up - _berries[i].Down;
        }

        int largestDown = 0;
        int largestUp = 0;

        if (positive.Count != 0) {
            largestDown = _berries[positive[^1]].Down;
        }
        if (negative.Count != 0) {
            largestUp = _berries[negative[0]].Up;
        }

        return Math.Max(largestHeight + largestDown, largestHeight + largestUp);
    }

    private List<int> Combine(List<int> positive, List<int> negative) {
        var combined = new List<int>(_berriesCount);
        combined.AddRange(positive);
        combined.AddRange(negative);

        return combined;
    }

    private IEnumerable<int> GetPositive() {
        int largestDownIndex = -1;
        for (int i = 0; i < _berriesCount; ++i) {
            if (_berries[i].Up - _berries[i].Down > 0) {
                if (largestDownIndex == -1 || _berries[i].Down > _berries[largestDownIndex].Down) {
                    if (largestDownIndex != -1) {
                        yield return largestDownIndex;
                    }
                    largestDownIndex = i;
                } else {
                    yield return i;
                }
            }
        }

        if (largestDownIndex != -1) {
            yield return largestDownIndex;
        }
    }

    private IEnumerable<int> GetNegative() {
        int largestUpIndex = -1;
        for (int i = 0; i < _berriesCount; ++i) {
            if (_berries[i].Up - _berries[i].Down <= 0) {
                if (largestUpIndex == -1 || _berries[i].Up > _berries[largestUpIndex].Up) {
                    largestUpIndex = i;
                }
            }
        }

        if (largestUpIndex != -1) {
            yield return largestUpIndex;
        }

        for (int i = 0; i < _berriesCount; ++i) {
            if (_berries[i].Up - _berries[i].Down <= 0 && i != largestUpIndex) {
                yield return i;
            }
        }
    }
}

public struct Berry {
    public int Up { get; set; }

    public int Down { get; set; }

    public Berry(int[] berry) =>
        (Up, Down) = (berry[0], berry[1]);
}

public class Program {
    static int[] Input() =>
        Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

    static void Main(string[] args) {
        int berriesCount = int.Parse(Console.ReadLine());
        var berries = new Berry[berriesCount];
        for (int i = 0; i < berriesCount; ++i) {
            berries[i] = new Berry(Input());
        }

        var ambitiousSnail = new AmbitiousSnail(berries, berriesCount);
        (long largestHeight, List<int> order) = ambitiousSnail.GetAnswer();

        Console.WriteLine(largestHeight);
        foreach (var index in order) {
            Console.Write($"{index + 1} ");
        }
    }
}