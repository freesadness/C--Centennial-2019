using System;

namespace Lab_6
{
    public enum SongGenre
    {
        Unclasified, Pop, Rock, Blues, Country, Metal, Soul
    }
    [Serializable]
    public class Song
    {
        public string Artist { get; }
        public SongGenre Genre { get; }
        public double Length { get; }
        public string Title { get; }
        public Song(string title, string artist, double length, SongGenre genre)
        {
            Artist = artist;
            Title = title;
            Length = length;
            Genre = genre;
        }
        public override string ToString()
        {
            return $"{Title} by {Artist} ({Genre}) {Length:f}min";
        }
    }

}
