using System.Collections.Generic;

namespace MEFDemo
{
    public interface IMoviePersistor
    {
        void Persist(List<Movie> movies);
    }
}