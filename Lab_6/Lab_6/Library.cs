using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab_6
{
    public static class Library
    {
        private static List<Song> _songs = new List<Song>();

        private static void DisplaySongs(IEnumerable<Song> songs)
        {
            foreach (var song in songs)
            {
                Console.WriteLine(song.ToString());
            }
        }

        public static void DisplaySongs()
        {
            DisplaySongs(_songs);
        }

        public static void DisplaySongs(double longerThan)
        {
            IEnumerable<Song> songs = _songs.Where(song => song.Length >= longerThan );
            DisplaySongs(songs);
        }

        public static void DisplaySongs(SongGenre genre)
        {
            IEnumerable<Song> songs = _songs.Where(song => song.Genre == genre);
            DisplaySongs(songs);
        }

        public static void DisplaySongs(string artist)
        {
            IEnumerable<Song> songs = _songs.Where(song => song.Artist == artist);
            DisplaySongs(songs);
        }

        public static void LoadSongs(string fileName)
        {
            using (StreamReader reader = new StreamReader($@"{fileName}"))
            {
                string title;
                while ((title = reader.ReadLine()) != null)
                {
                    string artist = reader.ReadLine();
                    string sLength = reader.ReadLine();
                    double length = Convert.ToDouble(sLength);
                    SongGenre genre = (SongGenre)Enum.Parse(typeof(SongGenre), reader.ReadLine());
                    Song song = new Song(title, artist, length, genre);
                    _songs.Add(song);
                }
            }
        
        }

        public static void SaveSongs(string fileName)
        {
            using (StreamWriter writer = new StreamWriter($@"{fileName}"))
            {
                foreach (Song song in _songs)
                {
                    writer.WriteLine(song.Title);
                    writer.WriteLine(song.Artist);
                    writer.WriteLine(song.Length);
                    writer.WriteLine(song.Genre);
                }
            }
            Console.WriteLine("\n\nWhere should songs be serialized: ");
            string saveFilePath = Console.ReadLine();
            using (var fileStream = new FileStream($@"{saveFilePath}", FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, _songs);
            }
            using (var fileStream = new FileStream($@"{saveFilePath}", FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                List<Song> songs = (List<Song>)formatter.Deserialize(fileStream);
                Console.WriteLine("\n\n Success to deserialize the file back to List<Song>");
                DisplaySongs(songs);
            }
        }
    }

}
