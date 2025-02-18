namespace patterns.Iterator;

public class PlaylistIterator : IIterator<Song>
{
    private readonly Playlist playlist;
    private int index = 0;

    public PlaylistIterator(Playlist playlist)
    {
        this.playlist = playlist;
    }

    public bool HasNext()
    {
        return index < playlist.Count;
    }

    public Song Next()
    {
        return playlist[index++];
    }
}