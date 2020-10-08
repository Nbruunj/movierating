
using MovieRatingsApplication.Interfaces;
using MovieRatingsJSONRepository;
using System;

namespace JsonReaderConsole
{
    public class Program
    {
        const string JSÒN_FILE_NAME = @"C:\Users\nbruu\Desktop\ratings.json";
        static void Main(string[] args)
        {
            IMovieRatingsRepository repo = new MovieRatingsRepository(JSÒN_FILE_NAME);
        }
    }
}
