using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMDemo
{
    public class Book
    {
        public List<Author> Authors { get; set; }
    }

    public class Author
    {
        public List<Book> Books { get; set; }
    }
    class Dummy
    {
        void M1()
        {
            var book = new Book();
            var author = new Author();
            
            book.Authors.Add(author);
            author.Books.Add(book);































            author
        }
    }
}
