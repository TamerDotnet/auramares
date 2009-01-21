using System.IO;

namespace Sample1
{
    public interface IFileLoader
    {
        Stream Load(string fileName);
    }
}