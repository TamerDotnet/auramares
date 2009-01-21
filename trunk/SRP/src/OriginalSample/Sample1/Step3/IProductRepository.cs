using System.Collections.Generic;

namespace Sample1.Step3
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetByFileName(string fileName);
    }
}