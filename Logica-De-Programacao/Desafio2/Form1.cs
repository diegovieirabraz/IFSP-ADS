using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desafio2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Triangulo triangulo = new Triangulo();

            triangulo.lado1 = Convert.ToDouble(textBox1.Text);
            triangulo.lado2 = Convert.ToDouble(textBox2.Text);
            triangulo.lado3 = Convert.ToDouble(textBox3.Text);  

            labelResultado.Text = triangulo.TipoTriangulo();
        }
    }
}
