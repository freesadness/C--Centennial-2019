using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Where should I load songs from: ");
            //string loadFilePath = Console.ReadLine();
            //Library.LoadSongs(loadFilePath);

            //Console.WriteLine("\n\nAll songs");
            //Library.DisplaySongs();

            //SongGenre genre = SongGenre.Rock;
            //Console.WriteLine("\n\n{0} songs", genre);
            //Library.DisplaySongs(genre);

            //string artist = "Bob Dylan";
            //Console.WriteLine("\n\nSongs by {0}", artist);
            //Library.DisplaySongs(artist);

            //double length = 5.0;
            //Console.WriteLine("\n\nSongs more than {0}mins", length);
            //Library.DisplaySongs(length);

            //Console.WriteLine("\n\nWhere should songs be backed up: ");
            //string saveFilePath = Console.ReadLine();
            //Library.SaveSongs(saveFilePath);

            //------------------------------------------------------------------------
            //Console.Write("Where should I load songs from: ");
            //string loadFilePath = Console.ReadLine();
            //LibraryPlus.LoadSongs(loadFilePath);

            //Console.WriteLine("\n\nAll songs");
            //LibraryPlus.DisplaySongs();

            //SongGenre genre = SongGenre.Rock;
            //Console.WriteLine("\n\n{0} songs", genre);
            //LibraryPlus.DisplaySongs(genre);

            //string artist = "Bob Dylan";
            //Console.WriteLine("\n\nSongs by {0}", artist);
            //LibraryPlus.DisplaySongs(artist);

            //double length = 5.0;
            //Console.WriteLine("\n\nSongs more than {0}mins", length);
            //LibraryPlus.DisplaySongs(length);

            //Console.WriteLine("\n\nSaving the songs.. ");
            //LibraryPlus.SaveSongs();

            //------------------------------------------------------------------------
            Console.WriteLine("Road songs from a serialized file at Debug directory...");
            LibraryPlus.LoadSongs();
            LibraryPlus.DisplaySongs();
            Console.WriteLine("Delete songs");
            LibraryPlus.DeleteSongs(SongGenre.Rock);
            LibraryPlus.DisplaySongs();

            Console.WriteLine("\n\nPress any key to exit");
            Console.ReadKey();
        }
    }


}
