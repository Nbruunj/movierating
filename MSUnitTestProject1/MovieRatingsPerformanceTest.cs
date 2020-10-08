using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieRatingsApplication.Services;
using MovieRatingsJSONRepository;


namespace MSUnitTestProject1
{
    [TestClass]
    public class MovieRatingsPerformanceTest
    {

        private static MovieRatingsRepository repo;

        [ClassInitialize]
        public static void SetUpTest(TestContext tc)
        {
            repo = new MovieRatingsRepository(@"C:\Users\nbruu\Desktop\ratings.json");
        }

        [TestMethod]
        [Timeout(1000)]
        public void GetNumberofReviewsFromReviewer()
        {
            MovieRatingsServiceLinq service = new MovieRatingsServiceLinq(repo);
            service.GetNumberOfReviewsFromReviewer(1);
        }
    }
}
