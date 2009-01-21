using System;
using System.Windows.Forms;

namespace Sample1.Step12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "XML Document (*.xml)|*.xml|All Files (*.*)|*.*";
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtFileName.Text = openFileDialog1.FileName;
                btnLoad.Enabled = true;
            }
        }

        private IProductRepository repository;

        private void btnLoad_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            var fileName = txtFileName.Text;
            var products = repository.GetByFileName(fileName);
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
    }
}
