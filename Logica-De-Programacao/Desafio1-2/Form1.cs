using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desafio1_2
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                PesoIdeal pesoIdeal = new PesoIdeal();

                pesoIdeal.altura = Convert.ToDouble(textBoxAltura.Text);
                pesoIdeal.sexo = Convert.ToInt32(textBoxSexo.Text);

                labelResultado.Text = pesoIdeal.CalcularPesoIdeal().ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Erro: Insira valores numerio válidos");
            }
        }
    }
}