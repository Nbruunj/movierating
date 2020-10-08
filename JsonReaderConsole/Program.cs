using System;
using Comp1.Core.Interfaces;
using MovieRatingsApplication.InfraStructure;

namespace JsonReaderConsole
{
    class Program
    {
        const string JSÒN_FILE_NAME = @"C:\Users\nbruu\Desktop\ratings.json";
        static void Main(string[] args)
        {
            IMovieRatingsRepository repo = new MovieRatingsRepository(JSÒN_FILE_NAME);
        }
    }
}
