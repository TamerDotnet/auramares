using System.Collections.Generic;

namespace Sample1
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetByFileName(string fileName);
    }
}