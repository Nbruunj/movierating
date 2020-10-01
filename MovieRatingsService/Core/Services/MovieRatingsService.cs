using MovieRatingsApplication.Core.Interfaces;
using MovieRatingsApplication.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRatingsApplication.Core.Services
{
    public class MovieRatingsService
    {
        private readonly IMovieRatingsRepository RatingsRepository;

        public MovieRatingsService(IMovieRatingsRepository repo)
        {
            RatingsRepository = repo;
        }

        public int NumberOfMoviesWithGrade(int grade)
        {
            if (grade < 1 || grade > 5)
            {
                throw new ArgumentException("Grade must be 1 - 5");
            }

            HashSet<int> movies = new HashSet<int>();
            foreach (MovieRating rating in RatingsRepository.GetAllMovieRatings())
            {
                if (rating.Grade == grade)
                {
                    movies.Add(rating.Movie);
                }
            }
            return movies.Count;
        }

        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {
            int count = 0;
            foreach (MovieRating m in RatingsRepository.GetAllMovieRatings())
            {
                if (m.Reviewer == reviewer)
                {
                    count++;
                }
            }
            return count;

            //return RatingsRepository.GetAllMovieRatings()
            //    .Where(r => r.Reviewer == reviewer)
            //    .Count();
        }

        public List<int> GetMoviesWithHighestNumberOfTopRates()
        {
            var movie5 = RatingsRepository.GetAllMovieRatings()
                .Where(r => r.Grade == 5)
                .GroupBy(r => r.Movie)
                .Select(group => new
                {
                    Movie = group.Key,
                    MovieGrade5 = group.Count()
                });

            int max5 = movie5.Max(grp => grp.MovieGrade5);

            return movie5
                .Where(grp => grp.MovieGrade5 == max5)
                .Select(grp => grp.Movie)
                .ToList();
        }
        public double GetAverageRateFromReviewer(int reviewer, int grade)
        {
            double count = 0;
            double gcount = 0;
            double gradeCount = 0;
            foreach (MovieRating m in RatingsRepository.GetAllMovieRatings())
            {

                if (m.Reviewer == reviewer)
                {
                    count++;
                }

                if (m.Grade == grade)
                {
                    gradeCount = gcount + grade;
                }

            }
            return gradeCount / count;
        }

        public int GetNumberOfRatesByReviewer(int reviewer, int grade)
        {
            int count = 0;
            foreach (MovieRating m in RatingsRepository.GetAllMovieRatings())
            {
                if (m.Grade == grade & m.Reviewer == reviewer)
                {
                    count++;
                }
            }
            return count;
        }

        public int GetNumberOfReviews(int movie)
        {
            int count = 0;
            foreach (MovieRating m in RatingsRepository.GetAllMovieRatings())
            {
                if (m.Movie == movie)
                {
                    count++;
                }
            }
            return count;
        }

        public double GetAverageRateOfMovie(int movie, int grade)
        {
            double count = 0;
            double gcount = 0;
            double gradeCount = 0;
            foreach (MovieRating m in RatingsRepository.GetAllMovieRatings())
            {

                if (m.Movie == movie)
                {
                    count++;
                }

                if (m.Grade == grade)
                {
                    gradeCount = gcount + grade;
                }

            }
            return gradeCount / count;
        }

        public int GetNumberOfRates(int movie, int grade)
        {
            int count = 0;
            foreach (MovieRating m in RatingsRepository.GetAllMovieRatings())
            {
                if (m.Movie == movie && m.Grade == grade)
                {
                    count++;
                }
            }
            return count;
        }

        public List<int> GetMostProductiveReviewers()
        {
            var reviewer1 = RatingsRepository.GetAllMovieRatings()
                .Where(r => r.Reviewer == 1)
                .GroupBy(r => r.Movie)
                .Select(group => new
                {
                    reviewer = group.Key,
                    Reviewer1 = group.Count()
                });
            int max1 = reviewer1.Max(grp => grp.Reviewer1);
            return reviewer1
                .Where(grp => grp.Reviewer1 == max1)
                .Select(grp => grp.reviewer)
                .ToList();
        }

        public List<int> GetTopRatedMovies(int amount)
        {
            return RatingsRepository.GetAllMovieRatings()
                .GroupBy(r => r.Movie)
                .Select(grp => new
                {
                    Movie = grp.Key,
                    GradeAvg = grp.Average(x => x.Grade)
                })
                .OrderByDescending(grp => grp.GradeAvg)
                .OrderByDescending(grp => grp.GradeAvg)
                .Select(grp => grp.Movie)
                .Take(amount)
                .ToList();
        }
        
        public List<int> GetTopMoviesByReviewer()
        {

            var topmoviereviewer = RatingsRepository.GetAllMovieRatings()
                .Where(r => r.Movie == 5)
                .GroupBy(r => r.Reviewer)
                .Select(group => new
                {
                    Movie = group.Key,
                    MovieReviewer5 = group.Count()
                });

            var max5 = topmoviereviewer.Max(grp => grp.MovieReviewer5);

            return topmoviereviewer
                .Where(grp => grp.MovieReviewer5 == max5)
                .Select(grp => grp.Movie)
                .ToList();

            
        }
        /*
        public List<int> GetReviewersByMovie()
        {

        }
        */
    }
}
