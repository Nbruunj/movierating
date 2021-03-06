
using System;
using System.Collections.Generic;
using System.Diagnostics;

using MovieRatingsApplication.Interfaces;
using MovieRatingsApplication.Services;
using Xunit;

namespace XUnitTestProject___PerformanceTest
{
    public class MovieRatingsServiceLinqPerformanceTest : IClassFixture<TestFixture>
    {
        //const string JS�N_FILE_NAME = @"C:\Users\nbruu\Desktop\ratings.json";

        private IMovieRatingsRepository repository;

        private int reviewerMostReviews;
        private int movieMostReviews;


        public MovieRatingsServiceLinqPerformanceTest(TestFixture data)
        {
            repository = data.Repository;
            reviewerMostReviews = data.ReviewerMostReviews;
            movieMostReviews = data.MovieMostReviews;
        }

        private double TimeInSeconds(Action ac)
        {
            Stopwatch sw = Stopwatch.StartNew();
            ac.Invoke();
            sw.Stop();
            return sw.ElapsedMilliseconds / 1000d;
        }

        [Fact]
        public void GetNumberOfReviewsFromReviewer()
        {
            IMovieRatingsService mrs = new MovieRatingsServiceLinq(repository);

            double seconds = TimeInSeconds(() =>
            {
                int result = mrs.GetNumberOfReviewsFromReviewer(reviewerMostReviews);
            });

            Assert.True(seconds <= 1);
        }
    }
}
