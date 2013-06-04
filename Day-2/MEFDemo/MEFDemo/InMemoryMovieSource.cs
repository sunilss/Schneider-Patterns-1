using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace MEFDemo
{
    [Export(typeof(IMovieSource))]
    public class InMemoryMovieSource : IMovieSource
    {
        public List<Movie> GetMovies()
        {
            return new List<Movie>()
                {
                    new Movie(){Id = 101, Title = "Title - 11", Price = 101, Category = 1},
                    new Movie(){Id = 102, Title = "Title - 17", Price = 120, Category = 2},
                    new Movie(){Id = 103, Title = "Title - 13", Price = 170, Category = 1},
                    new Movie(){Id = 103, Title = "Title - 19", Price = 130, Category = 2},
                    new Movie(){Id = 105, Title = "Title - 12", Price = 160, Category = 1}
                };
        }
    }
}