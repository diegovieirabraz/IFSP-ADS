using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double numero1 = Convert.ToDouble(txtNumber1.Text);
            double numero2 = Convert.ToDouble(txtNumber2.Text);
            double result = numero1 * numero2;
           label1.Text = result.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Teste";
        }
    }
}
