using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Storage
{
    public class BinarySerializerStorage : IBookListStorage
    {
        private readonly string pathFile;

        public BinarySerializerStorage(string pathFile)
        {
            this.pathFile = pathFile;
        }

        public List<Book> LoadBooks()
        {
            List<Book> books = new List<Book>();

            FileStream fstream = File.Open(pathFile, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            books = (List<Book>)binaryFormatter.Deserialize(fstream);
            fstream.Close();

            return books;
        }

        public void SaveBooks(IEnumerable<Book> books)
        {
            FileStream fstream = File.Open(pathFile, FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fstream, books);
            fstream.Close();
        }
    }
}
