using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace patterns.Iterator;

public class Song
{
    public string Title { get; set; }
    public string Artist { get; set; }

    public Song(string title, string artist)
    {
        Title = title;
        Artist = artist;
    }
    
    public override string ToString()
    {
        return $"{Title} by {Artist}";
    }
}