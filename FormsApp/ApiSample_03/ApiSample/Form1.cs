using Hotcakes.CommerceDTO.v1.Catalog;
using Hotcakes.CommerceDTO.v1.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            textBox3.Text = product.Sku;
            textBox4.Text = product.SiteCost.ToString();            
            textBox5.Text = product.SitePrice.ToString();
            textBox6.Text = product.LongDescription;
            var X = product.ImageFileMedium;
            var Xjo=X.Replace(" ","_");
            string currentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string filePath = Path.Combine(currentDirectory,"Shelbykepek",Xjo);
            //C:\Users\balazsbodnar\Source\Repos\RF_Shelby\FormsApp\ApiSample_03\ApiSample\Shelbykepek\334990619_751502982999180_7066637949454292715_n.png
           Bitmap oImage = new Bitmap(filePath);
           Bitmap resized = new Bitmap(oImage, new Size(220, 270));
           pictureBox1.Image = resized;
            //var image = _proxy.ProductImagesFind(product.Bvin);
            //pictureBox1.Image = new Bitmap(_proxy.ProductImagesFind(product.Bvin).Content.FileName);
            //pictureBox1.Image=Image.FromFile(filePath);
            _listId = listBox1.Items.IndexOf(product.ProductName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductDTO product = _products.Where(p => p.ProductName == listBox1.Items[_listId]).FirstOrDefault();

            product.ProductName=textBox2.Text;
            product.SitePrice = decimal.Parse(textBox5.Text);
            product.Sku = textBox3.Text;
            product.LongDescription=textBox6.Text;
            _proxy.ProductsUpdate(product);
            Form1_Load(sender, e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var products = from x in _products
                           where x.ProductName.Contains(textBox1.Text)
                           select x.ProductName;
            listBox1.DataSource = products.ToList();
            listBox1.DisplayMember = "ProductName";
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox2, "nem lehet üres");
            }
        }

        private void textBox2_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox2, string.Empty);
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox3, "nem lehet üres");
            }
        }

        private void textBox3_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox3,String.Empty);
        }

        public bool ValidateSellPrice(string input)
        {
            Regex regex = new Regex("^[0-9]{4,6}$");
            return regex.IsMatch(input);
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateSellPrice(textBox5.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox5, "4-6 számjegyű számként add meg az árat!");
            }
        }

        private void textBox5_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox5,String.Empty);
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox6, "nem lehet üres");
            }
        }

        private void textBox6_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox6, String.Empty);
        }
    }
}
