using System.Collections.Generic;

namespace Sample1
{
public interface IProductView
{
    void Initialize(ProductPresenter presenter);
    string GetFileName();
    void ShowProducts(IEnumerable<Product> products);
    void SetFileName(string fileName);
}
}