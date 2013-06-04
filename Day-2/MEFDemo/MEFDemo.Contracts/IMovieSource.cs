using System.Collections.Generic;

namespace MEFDemo
{
    public interface IMovieSource
    {
        List<Movie> GetMovies();
    }
}