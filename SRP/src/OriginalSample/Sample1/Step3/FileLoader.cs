using System.IO;

namespace Sample1.Step3
{
    public interface IFileLoader
    {
        Stream Load(string fileName);
    }

    public class FileLoader : IFileLoader
    {
        public Stream Load(string fileName)
        {
            return new FileStream(fileName, FileMode.Open);
        }
    }
}