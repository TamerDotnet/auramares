using System.Collections.Generic;

namespace Sample1.Step12
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetByFileName(string fileName);
    }
}