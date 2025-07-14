using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Classificacao classificacao = new Classificacao();

            classificacao.exameI = Convert.ToDouble(textBox1.Text);
            classificacao.exameII = Convert.ToDouble(textBox2.Text);
            classificacao.exameIII = Convert.ToDouble(textBox3.Text);
            classificacao.exameIV = Convert.ToDouble(textBox4.Text);
            classificacao.exameV = Convert.ToDouble(textBox5.Text);

            MessageBox.Show(classificacao.CalculoNota());

        }
    }
}
