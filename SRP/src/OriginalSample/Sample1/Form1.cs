﻿using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace Sample1
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

        private void btnLoad_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            var fileName = txtFileName.Text;
            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                var reader = XmlReader.Create(fs);
                while (reader.Read())
                {
                    if(reader.Name != "product") continue;
                    var id = reader.GetAttribute("id");
                    var name = reader.GetAttribute("name");
                    var unitPrice = reader.GetAttribute("unitPrice");
                    var discontinued = reader.GetAttribute("discontinued");
                    var item = new ListViewItem(new string[]{id, name, unitPrice, discontinued});
                    listView1.Items.Add(item);
                }
            }
        }
    }
}
