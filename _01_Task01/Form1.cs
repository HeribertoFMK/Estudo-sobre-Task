using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;

namespace _01_Task01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private  void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        // Rede,Armazenamento,Tela/Display.
        private async void btnBaixar_Click(object sender, EventArgs e)
        {
            // Task - Asynchrono.
            string endereço = txtSite.Text;
            WebClient web = new WebClient();
            //string html = web.DownloadString(endereço);
            string html = await web.DownloadStringTaskAsync(new Uri(endereço));

            txtResultado.Text = html;


        }
    }
}
