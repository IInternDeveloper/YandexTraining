using System;
using System.Collections.Generic;
using System.Linq;


public class WordReplacer {
    private HashSet<string> _dictionary;

    public WordReplacer(HashSet<string> dictionary) =>
        _dictionary = dictionary;

    public string[] GetReplacedWords(string[] words) {
        int wordsCount = words.Length;
        var replacedWords = new string[wordsCount];
        for (int i = 0; i < wordsCount; ++i) {
            replacedWords[i] = GetReplacedWord(words[i]);
        }

        return replacedWords;
    }

    private string GetReplacedWord(string word) {
        int wordLength = word.Length;
        for (int i = 1; i <= wordLength; ++i) {
            string subword = word[..i];
            if (_dictionary.Contains(subword)) {
                return subword;
            }
        }

        return word;
    }
}

public class Program {
    static string[] Input() => Console.ReadLine().Split();

    static void Main(string[] args) {
        var dictionary = Input().ToHashSet<string>();
        var words = Input();

        var wordsReplacer = new WordReplacer(dictionary);
        var replacedWords = wordsReplacer.GetReplacedWords(words);

        foreach (var word in replacedWords) {
            Console.Write($"{word} ");
        }
    }
}