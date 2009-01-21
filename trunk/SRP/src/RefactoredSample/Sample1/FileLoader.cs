using System.IO;

namespace Sample1
{
    public class FileLoader : IFileLoader
    {
        public Stream Load(string fileName)
        {
            return new FileStream(fileName, FileMode.Open);
        }
    }
}