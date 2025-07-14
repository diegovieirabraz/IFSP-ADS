using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcularVolume
{
    public partial class Form1 : Form
    {
        CalculoVolume v;


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             double largura = double.Parse(textBoxLargura.Text);
             double comprimento = double.Parse(textBoxComprimento.Text);
            double altura = double.Parse(textBoxAltura.Text);

            v = new CalculoVolume(comprimento, altura, largura);

            labelVolume.Text = v.CalcularVolume().ToString() + "m³";
        }
    }
}
