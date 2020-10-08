
using Comp1.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieRatingsApplication.InfraStructure;


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
