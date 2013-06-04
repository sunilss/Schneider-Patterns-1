using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Xml.Linq;

namespace MEFDemo
{
    [Export(typeof(IMoviePersistor))]
    public class XmlMoviePersistor : IMoviePersistor
    {
        public void Persist(List<Movie> movies)
        {
            new XElement("Movies", movies.Select(m => new XElement("Movie",
                                                                   new XElement("Id", m.Id),
                                                                   new XElement("Title", m.Title),
                                                                   new XElement("Price", m.Price),
                                                                   new XElement("Category",m.Category)))).Save("movies.xml");
        }
    }
}