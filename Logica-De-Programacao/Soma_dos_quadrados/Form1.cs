using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soma_dos_quadrados
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double numero1 = Double.Parse(textBox1.Text);
            double numero2 = Double.Parse(textBox2.Text);
            double numero3 = Double.Parse(textBox3.Text);

            SomaQuadrados s = new SomaQuadrados(numero1, numero2, numero3);

            labelResultado.Text = s.CalcularSomaQuadrados().ToString();
        }
    }
}
