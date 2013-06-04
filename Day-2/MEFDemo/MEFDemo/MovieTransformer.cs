using System.ComponentModel.Composition;

namespace MEFDemo
{

    public interface IMovieTransformer
    {
        void Transform();
    }

    [Export(typeof(IMovieTransformer))]
    public class MovieTransformer : IMovieTransformer
    {
        private  IMovieSource _source;
        private  IMoviePersistor[] _persistors;

        [Import(typeof(IMovieSource))]
        public IMovieSource Source
        {
            get { return _source; }
            set { _source = value; }
        }

        [ImportMany(typeof(IMoviePersistor))]
        public IMoviePersistor[] Persistor
        {
            get { return _persistors; }
            set { _persistors = value; }
        }


        /*public MovieTransformer(IMovieSource source, IMoviePersistor persistor)
        {
            _source = source;
            _persistor = persistor;
        }*/

        public void Transform()
        {
            foreach (var persistor in Persistor)
            {
                persistor.Persist(Source.GetMovies());    
            }
            
        }
    }
}