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
        public Form1()
        {
            InitializeComponent();
            _proxy = new Api(_url, _key);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            var snaps = _proxy.CategoriesFindAll();
            var a = _proxy.ProductsFindAll();

            a.Content.ForEach(i => listBox1.Items.Add(i.ProductName));
        }
    }
}
