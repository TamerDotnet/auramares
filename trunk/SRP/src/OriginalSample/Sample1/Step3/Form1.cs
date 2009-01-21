using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Sample1.Step3
{
    public partial class Form1 : Form, IProductView
    {
        private ProductPresenter presenter;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            presenter.BrowseForFileName();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            presenter.GetProducts();
        }

        public void ShowProducts(IEnumerable<Product> products)
        {
            listView1.Items.Clear();
            foreach (Product product in products)
            {
                var item = new ListViewItem(new[]
                                                {
                                                    product.Id.ToString(),
                                                    product.Name,
                                                    product.UnitPrice.ToString(),
                                                    product.Discontinued.ToString()
                                                });
                listView1.Items.Add(item);
            }
        }

        public void Initialize(ProductPresenter presenter)
        {
            this.presenter = presenter;
        }

        public string GetFileName()
        {
            return txtFileName.Text;
        }

        public void SetFileName(string fileName)
        {
            txtFileName.Text = fileName;
            btnLoad.Enabled = true;
        }
    }
}
