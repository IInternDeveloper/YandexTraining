using System;
using System.Collections.Generic;


public class Anagrams {
    public static bool IsAnagrams(string wordA, string wordB) {
        if (wordA.Length != wordB.Length) {
            return false;
        }

        var letters = ConvertToDictionary(wordA);
        foreach (var symbol in wordB) {
            if (!letters.ContainsKey(symbol) || --letters[symbol] < 0) {
                return false;
            }
        }

        return true;
    }

    private static Dictionary<char, int> ConvertToDictionary(string word) {
        var converted = new Dictionary<char, int>();
        foreach (var symbol in word) {
            if (!converted.ContainsKey(symbol)) {
                converted[symbol] = 0;
            }
            converted[symbol]++;
        }

        return converted;
    }
}

public class Program {
    static string GetString() => Console.ReadLine();

    static void Main(string[] args) {
        string wordA = GetString();
        string wordB = GetString();

        Console.WriteLine(
            Anagrams.IsAnagrams(wordA, wordB) ? "YES" : "NO");
    }
}