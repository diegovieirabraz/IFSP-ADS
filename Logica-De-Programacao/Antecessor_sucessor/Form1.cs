using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Antecessor_sucessor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double numero = Convert.ToDouble(textBox1.Text);

            AntecessorSucessor x = new AntecessorSucessor(numero);

            labelAntecessor.Text = "Antecessor é " + x.CalcularAntecessor().ToString();
            labelSucessor.Text = "Sucessor é " + x.CalcularSucessor().ToString();   
        }
    }
}
