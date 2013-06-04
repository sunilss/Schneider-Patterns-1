using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentalReport
{
    class Program
    {
        private static Movies movies;

        static void Main(string[] args)
        {
            movies = new Movies();
            movies.Add(new Movie(11, "Title -1", 1, new DateTime(2013, 05, 05)));
            movies.Add(new Movie(13, "Title -2", 2, new DateTime(2013, 05, 02)));
            movies.Add(new Movie(21, "Title -4", 1, new DateTime(2013, 05, 19)));
            movies.Add(new Movie(19, "Title -3", 3, new DateTime(2013, 05, 20)));
            movies.Add(new Movie(17, "Title -7", 2, new DateTime(2013, 05, 01)));
            movies.Add(new Movie(16, "Title -9", 1, new DateTime(2013, 05, 15)));

            PrintMovies("Initial List");

            movies.Sort();
            PrintMovies("After sorting");
            
            movies.Sort( new MovieComparerByReleaseDate());
            PrintMovies("After Sorting by ReleaseDate");            
            
            //movies.Sort(Program.CompareMovieByPriceCode);

            /*movies.Sort(delegate (Movie left, Movie right)
            {
                if (left.PriceCode < right.PriceCode) return -1;
                if (left.PriceCode > right.PriceCode) return 1;
                return 0;
            });*/
            movies.Sort(MovieComparer.ByPriceCode);
            PrintMovies("After sorting by PriceCode");

            var moviesWithPriceCode1 = movies.Filter(new MovieSpecificationByPriceCode(1));
            PrintMovies(moviesWithPriceCode1,"Movies with price code = 1");

            IsSatisfiedByDelegate moviesWithIdGT15 = (m) => m.Id > 15;
            PrintMovies(movies.Filter(moviesWithIdGT15),"Movies with ID > 15");
            Console.ReadLine();
        }

        public static int CompareMovieByPriceCode(Movie left, Movie right)
        {
            if (left.PriceCode < right.PriceCode) return -1;
            if (left.PriceCode > right.PriceCode) return 1;
            return 0;
        }

        private static void PrintMovies(string title)
        {
            Console.WriteLine();
            Console.WriteLine(title);
            Console.WriteLine("====================================================");
            foreach (var movie in movies)
            {
                Console.WriteLine(movie);
            }
            Console.WriteLine();
        }

        private static void PrintMovies(IEnumerable<Movie> moviesToPrint, string title)
        {
            Console.WriteLine();
            Console.WriteLine(title);
            Console.WriteLine("====================================================");
            foreach (var movie in moviesToPrint)
            {
                Console.WriteLine(movie);
            }
            Console.WriteLine();
        }


    }

    public static class MovieComparer
    {
        public static CompareMovieDelegate ByPriceCode = (left, right) =>
            {
                if (left.PriceCode < right.PriceCode) return -1;
                if (left.PriceCode > right.PriceCode) return 1;
                return 0;
            };

        public static CompareMovieDelegate ById = (left, right) =>
        {
            if (left.Id < right.Id) return -1;
            if (left.Id > right.Id) return 1;
            return 0;
        };

        public static CompareMovieDelegate ByReleaseDate = (left, right) =>
        {
            if (left.ReleaseDate < right.ReleaseDate) return -1;
            if (left.ReleaseDate > right.ReleaseDate) return 1;
            return 0;
        };


    }
}
