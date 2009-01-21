using System.Windows.Forms;

namespace Sample1.Step3
{
public class ProductPresenter
{
    private readonly IOpenFileDialog openFileDialog;
    private readonly IProductRepository repository;
    private readonly IProductView view;

    public ProductPresenter()
    {
        view = new Form1();
        view.Initialize(this);
        repository = new ProductRepository();
        openFileDialog = new OpenFileDialogWrapper();
    }

    public IProductView View
    {
        get { return view; }
    }

    public void BrowseForFileName()
    {
        openFileDialog.Filter = "XML Document (*.xml)|*.xml|All Files (*.*)|*.*";
        var result = openFileDialog.ShowDialog();
        if (result == DialogResult.OK)
            view.SetFileName(openFileDialog.FileName);
    }

    public void GetProducts()
    {
        var products = repository.GetByFileName(view.GetFileName());
        view.ShowProducts(products);
    }
}
}