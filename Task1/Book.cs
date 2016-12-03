using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    [Serializable]
    public class Book: IComparable<Book>, IComparable, IEquatable<Book>
    {
        public string Title { get; }
        public int CountPages { get; }
        public int PublicationYear { get; }
        public string Author { get; }

        public Book(string title, int countPages, int publicationYear, string author)
        {
            if (String.IsNullOrEmpty(title) || (countPages < 1) || String.IsNullOrEmpty(author))
                throw new ArgumentException();

            Author = author;
            Title = title;
            CountPages = countPages;
            PublicationYear = publicationYear;

        }

        public bool Equals(Book other)
        {
            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return MakeEquals(this, other);
        }

        public override string ToString()
        {
            return $"Title: {Title}; Count of pages: {CountPages}; Publication year: {PublicationYear}; Author: {Author};";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null) || !(obj is Book))
                return false;

            if (ReferenceEquals(obj, this))
                return true;

            return MakeEquals(this, (Book)obj);
        }

        public override int GetHashCode()
        {
            return Author.GetHashCode() + Title.GetHashCode() + CountPages.GetHashCode() + PublicationYear.GetHashCode();
        }

        public int CompareTo(Book other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentException();

            return this.CountPages.CompareTo(other.CountPages);
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Book))
                throw new ArgumentException();

            Book comparerBook = (Book)obj;
            return CompareTo(comparerBook);
        }

        private bool MakeEquals(Book book1, Book book2)
        {
            if (book1.Title == book2.Title && book1.Author == book2.Author
                && book1.CountPages == book2.CountPages && book1.PublicationYear == book2.PublicationYear)
                return true;
            
            return false;
        }

        public static bool operator == (Book book1, Book book2)
        { 
            return book1.Equals(book2); 
        }

        public static bool operator != (Book book1, Book book2)
        { 
            return !(book1 == book2); 
        }
    }
}
