using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Storage
{
    public interface IBookListStorage
    {
        void SaveBooks(IEnumerable<Book> books);
        List<Book> LoadBooks();
    }
}
