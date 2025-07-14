using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pulverizacao
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int tipo = int.Parse(comboBox1.SelectedItem.ToString());
            double area = double.Parse(textBoxArea.Text);

            Acre acre = new Acre(tipo, area);

            double custoFinal = acre.CalcularCusto();

            labelResultado.Text = $"Valor a pagar é R$ {custoFinal:F2}";           
            

        }
    }
}
