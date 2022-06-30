using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TokoPunakawan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuMakanan().Show();
        }

        private void Pemesanan_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPemesanan().Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
