using System.Windows.Forms;

namespace Sample1
{
    public class ProductPresenter
    {
        private readonly IOpenFileDialog openFileDialog;
        private readonly IProductRepository repository;
        private readonly IProductView view;

        public IProductView View
        {
            get { return view; }
        }

        public ProductPresenter() : this(new Form1(), new ProductRepository(), new OpenFileDialogWrapper())
        {
        }

        public ProductPresenter(IProductView view, IProductRepository repository, IOpenFileDialog openFileDialog)
        {
            this.view = view;
            view.Initialize(this);
            this.repository = repository;
            this.openFileDialog = openFileDialog;
        }

        public void GetProducts()
        {
            var products = repository.GetByFileName(view.GetFileName());
            view.ShowProducts(products);
        }

        public void BrowseForFileName()
        {
            openFileDialog.Filter = "XML Document (*.xml)|*.xml|All Files (*.*)|*.*";
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
                view.SetFileName(openFileDialog.FileName);
        }
    }
}