using System;
using System.Collections.Generic;
using System.Linq;

public class Playlists {
    public static string[] CommonPlaylist(HashSet<string>[] playlists) {
        int playlistsCount = playlists.Length;
        var commonPlaylist = playlists[0];
        for (int i = 1; i < playlistsCount; ++i) {
            commonPlaylist.IntersectWith(playlists[i]);
        }

        var convertedToArray = commonPlaylist.ToArray();
        Array.Sort(convertedToArray);

        return convertedToArray;
    }
}

public class Program {
    static int GetInt() => int.Parse(Console.ReadLine());

    static void Main(string[] args) {
        int playlistsCount = GetInt();
        var playlists = new HashSet<string>[playlistsCount];

        int playlistSize = -1;
        for (int i = 0; i < playlistsCount; ++i) {
            playlistSize = GetInt();
            playlists[i] = Console.ReadLine().Split().ToHashSet<string>();
        }

        var commonPlaylist = Playlists.CommonPlaylist(playlists);

        Console.WriteLine(commonPlaylist.Length);
        foreach (var song in commonPlaylist) {
            Console.Write($"{song} ");
        }
    }
}