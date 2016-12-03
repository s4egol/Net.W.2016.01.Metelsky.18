using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;
using System.Xml.Linq;

namespace Storage
{
    public class XMLBookListStorage : IBookListStorage
    {
        private readonly string pathFile;

        public XMLBookListStorage(string pathFile)
        {
            this.pathFile = pathFile;
        }

        public List<Book> LoadBooks()
        {
            List<Book> books = new List<Book>();
            XDocument xdoc = XDocument.Load(pathFile);

            foreach (var element in xdoc.Element("books").Elements("book"))
            {
                XAttribute title = element.Attribute("name");
                XElement author = element.Element("author");
                XElement countPages = element.Element("countpages");
                XElement publicationYear = element.Element("publicationyear");

                books.Add(new Book(title.Value, int.Parse(countPages.Value), int.Parse(publicationYear.Value), author.Value));
            }

            return books;
        }

        public void SaveBooks(IEnumerable<Book> books)
        {
            XDocument doc = new XDocument();
            doc.Add(new XElement("books"));

            foreach (var book in books)
            {
                doc.Root.Add(new XElement("book",
                new XAttribute("name", book.Title),
                new XElement("author", book.Author),
                new XElement("countpages", book.CountPages),
                new XElement("publicationyear", book.PublicationYear)));
            }

            doc.Save(pathFile);
        }
    }
}
