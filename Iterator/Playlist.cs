namespace patterns.Iterator;

public class Playlist
{
    private readonly IList<Song> songs = new List<Song>();

    public void AddSong(Song song)
    {
        songs.Add(song);
    }

    public IIterator<Song> CreateIterator()
    {
        return new PlaylistIterator(songs);
    }

    public int Count => songs.Count;

    public Song this[int index] => songs[index];
}