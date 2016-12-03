using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public static class BookExtention
    {
        public static void Sort(this List<Book> list, IComparer<Book> comparer)
        {
            if (ReferenceEquals(list, null))
                throw new ArgumentNullException();

            if (ReferenceEquals(comparer, null))
                comparer = Comparer<Book>.Default;

            Array.Sort(list.ToArray(), comparer);
        }
    }
}
