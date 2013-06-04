using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using MEFDemo;

namespace MovieTransformerExtensions
{
    [Export(typeof(IMoviePersistor))]
    public class XmlAttributeMoviePersistor : IMoviePersistor
    {
        public void Persist(List<Movie> movies)
        {
            new XElement("Movies",movies.Select(m => new XElement("Movie",
                new XAttribute("Id", m.Id),
                new XAttribute("Title", m.Title),
                new XAttribute("Price", m.Price),
                new XAttribute("Category",m.Category)))).Save("movies-2.xml");
        }
    }
}
