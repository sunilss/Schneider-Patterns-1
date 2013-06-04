using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Text;

namespace MEFDemo
{
    [Export(typeof(IMoviePersistor))]
    public class CsvMoviePersistor : IMoviePersistor
    {
        public void Persist(List<Movie> movies)
        {
            var file = new StreamWriter("movies.txt", false, Encoding.UTF8);
            foreach (var movie in movies)
            {
                file.WriteLine(string.Format("{0},{1},{2},{3}",movie.Id, movie.Title, movie.Price,movie.Category));
            }
            file.Close();
        }
    }
}