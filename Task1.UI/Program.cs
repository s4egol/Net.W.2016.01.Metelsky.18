using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;
using Storage;
using Service;

namespace Task1.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var book1 = new Book("Название книги 1", 700, 1980, "Автор Книги");
            var book2 = new Book("Название книги 2", 900, 1983, "Автор Книги 2");
            Console.WriteLine(book1.ToString());
            Console.WriteLine(book1.CompareTo(book2));

            Console.WriteLine(book1.GetHashCode());
            Console.WriteLine(book2.GetHashCode());

            List<Book> books = new List<Book>();
            books.Add(book1);
            books.Add(book2);

            BookListService service = new BookListService(books);
            service.AddBook(new Book("Название книги 3", 800, 1980, "Автор Книги 3"));

            Book findBook = service.FindBookWithTag((book) => String.Compare(book.Author, "Автор Книги 2", StringComparison.InvariantCulture) == 0);
            Console.WriteLine();
            Console.WriteLine("Найденная книга:");

            if (findBook != null)
                Console.WriteLine(findBook.ToString());
            else 
                Console.WriteLine("Книга не найдена!");

            Console.WriteLine();

            BookListStorage storageBIN = new BookListStorage("E:/storageBIN");
            service.Save(storageBIN);

            XMLBookListStorage storageXML = new XMLBookListStorage("E:/storageXML");
            service.Save(storageXML);

            BinarySerializerStorage storage3 = new BinarySerializerStorage("E:/storageBinarySerialiser");
            service.Save(storage3);

            List<Book> loadDate = storageBIN.LoadBooks();
            for (int i = 0; i < loadDate.Count; i++)
            {
                Console.WriteLine(loadDate[i].ToString());
            }

            Console.WriteLine();

            loadDate.Clear();
            loadDate = storageXML.LoadBooks();
            for (int i = 0; i < loadDate.Count; i++)
            {
                Console.WriteLine(loadDate[i].ToString());
            }

            Console.WriteLine();

            loadDate.Clear();
            loadDate = storage3.LoadBooks();
            for (int i = 0; i < loadDate.Count; i++)
            {
                Console.WriteLine(loadDate[i].ToString());
            }
            Console.ReadKey();
        }
    }
}
