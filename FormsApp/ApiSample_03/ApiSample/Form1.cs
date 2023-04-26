using Hotcakes.CommerceDTO.v1.Catalog;
using Hotcakes.CommerceDTO.v1.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApiSample
{
    public partial class Form1 : Form
    {
        string _url = "http://20.234.113.211:8088";
        string _key = "1-eaf534a5-8297-43cd-a301-da0483a0f0f4";
        Api _proxy;
        List<ProductDTO> _products;
        int _listId=0;
        public Form1()
        {
            InitializeComponent();
            _proxy = new Api(_url, _key);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            var snaps = _proxy.CategoriesFindAll();
            _products = _proxy.ProductsFindAll().Content;

            listBox1.Items.Clear();
            _products.ForEach(i => listBox1.Items.Add(i.ProductName));
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductDTO product=_products.Where(p=>p.ProductName==(sender as ListBox).SelectedItem).FirstOrDefault();

            textBox2.Text = product.ProductName;
            //var image = _proxy.ProductImagesFind(product.Bvin);
            //pictureBox1.Image = new Bitmap(_proxy.ProductImagesFind(product.Bvin).Content.FileName);
            _listId=listBox1.Items.IndexOf(product.ProductName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductDTO product = _products.Where(p => p.ProductName == listBox1.Items[_listId]).FirstOrDefault();

            product.ProductName=textBox2.Text;

            _proxy.ProductsUpdate(product);
            Form1_Load(sender, e);
        }
    }
}
