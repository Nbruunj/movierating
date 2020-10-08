
using System;
using System.Collections.Generic;
using System.Text;
using MovieRatingsApplication.Model;

namespace MovieRatingsApplication.Interfaces
{
    public interface IMovieRatingsRepository
    {
        MovieRating[] Ratings { get; }            
    }
}
