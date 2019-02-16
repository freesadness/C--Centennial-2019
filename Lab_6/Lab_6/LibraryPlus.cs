using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab_6
{
    public static class LibraryPlus
    {
        private static List<Song> _songs = new List<Song>();
        private static readonly string defaultPath = Directory.GetCurrentDirectory();
        private static BinaryFormatter formatter = new BinaryFormatter();
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
            IEnumerable<Song> songs = _songs.Where(song => song.Length >= longerThan);
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
            // load the file from Lab_6/bin/Debug/, argument [fileName] must be "file name" only no extension
            using (StreamReader reader = new StreamReader($@"{defaultPath}/{fileName}.txt"))
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

        public static void SaveSongs()
        {
            using (var fileStream = new FileStream($@"{defaultPath}/serialized_library.txt", FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(fileStream, _songs);
                Console.WriteLine($@"{defaultPath}");
            }
        }

        public static void LoadSongs()
        {
            using (var fileStream = new FileStream($@"{defaultPath}/serialized_library.txt", FileMode.Open, FileAccess.Read))
            {
                List<Song> songs = (List<Song>)formatter.Deserialize(fileStream);
                _songs = songs;
            }
        }

        public static void DeleteSongs( SongGenre genre = SongGenre.Unclasified, string artist = null, string title =null, double length=0)
        {
            var songsFound = _songs.Where(song => song.Title == title || song.Artist == artist ||
                                                           song.Length == length || song.Genre == genre);
            foreach (var sf in songsFound.ToList<Song>())
            {
             _songs.Remove(sf);
            }
            SaveSongs();
        }
    }
}
