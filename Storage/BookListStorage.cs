using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Storage
{
    public class BookListStorage : IBookListStorage
    {
        private readonly string pathFile;

        public BookListStorage(string pathFile)
        {
            this.pathFile = pathFile;
        }

        public void SaveBooks(IEnumerable<Book> books)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(pathFile, FileMode.OpenOrCreate)))
            {
                foreach (var book in books)
                {
                    writer.Write(book.Author);
                    writer.Write(book.CountPages);
                    writer.Write(book.PublicationYear);
                    writer.Write(book.Title);
                }
            }
        }

        public List<Book> LoadBooks()
        {
            List<Book> books = new List<Book>();

            using (BinaryReader reader = new BinaryReader(File.Open(pathFile, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    string Author = reader.ReadString();
                    int CountOfPages = reader.ReadInt32();
                    int PublicationYear = reader.ReadInt32();
                    string Title = reader.ReadString();
                    books.Add(new Book(Title, CountOfPages, PublicationYear, Author));
                }
            }

            return books;
        }
    }
}
