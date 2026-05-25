string[] first = { "Track One", "Track Two" };
string[] second = { "Track Three" };

Playlist a = new Playlist(first);
Playlist b = new Playlist(second);

Console.WriteLine("Плейлист A:");
Print(a);

Console.WriteLine("Плейлист B:");
Print(b);

Console.WriteLine("A + B:");
Print(a + b);

Console.WriteLine("A - \"Bonus track\":");
Print(a - "Bonus track");

Console.WriteLine("++A:");
Print(++a);

static void Print(Playlist p)
{
    for (int i = 0; i < p.Songs.Count; i++)
    {
        Console.WriteLine($"  {i + 1}. {p.Songs[i]}");
    }

    Console.WriteLine();
}

class Playlist
{
    public List<string> Songs { get; }

    public Playlist(string[] songs)
    {
        Songs = new List<string>(songs ?? Array.Empty<string>());
    }

    public static Playlist operator +(Playlist left, Playlist right)
    {
        Playlist result = new Playlist(Array.Empty<string>());
        for (int i = 0; i < left.Songs.Count; i++)
        {
            result.Songs.Add(left.Songs[i]);
        }

        for (int i = 0; i < right.Songs.Count; i++)
        {
            result.Songs.Add(right.Songs[i]);
        }

        return result;
    }

    public static Playlist operator -(Playlist playlist, string song)
    {
        Playlist result = new Playlist(Array.Empty<string>());
        for (int i = 0; i < playlist.Songs.Count; i++)
        {
            result.Songs.Add(playlist.Songs[i]);
        }

        result.Songs.Add(song);
        return result;
    }

    public static Playlist operator ++(Playlist playlist)
    {
        playlist.Songs.Insert(0, "New track");
        return playlist;
    }
}
