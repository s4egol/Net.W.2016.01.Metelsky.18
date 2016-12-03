using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task1;
using Storage;

namespace Service
{
    public class BookListService
    {
        private List<Book> Books;

        public BookListService(List<Book> books)
        {
            if (books != null)
                Books = books;
        }

        public IEnumerable<Book> GetBooks()
        {
            return Books.ToArray();
        }

        public void AddBook(Book book)
        {
            if (ReferenceEquals(book, null))
                throw new ArgumentNullException();

            bool contains = Books.Contains(book);
            if (!contains)
                Books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(book, null))
                throw new ArgumentNullException();

            bool contains = Books.Contains(book);
            if (contains)
                Books.Remove(book);
        }

        public void SortBooksByTag(IComparer<Book> comparer)
        {
            if (ReferenceEquals(comparer, null))
                throw new ArgumentException();

            Books.Sort(comparer);
        }

        public Book FindBookWithTag(Predicate<Book> predicate)
        {
            if (ReferenceEquals(predicate, null))
                throw new ArgumentException();

            foreach (var book in Books)
            {
                if (predicate(book))
                    return new Book(book.Title, book.CountPages, book.PublicationYear, book.Author);
            }

            return null;
        }

        public void Save(IBookListStorage bookListStorage)
        { 
            if (ReferenceEquals(bookListStorage, null))
                throw new ArgumentNullException(); 

            bookListStorage.SaveBooks(Books); 
        }
    }
}
