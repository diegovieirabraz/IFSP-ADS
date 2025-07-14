using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pooexfibonacci
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int nTermo;

            label2.Text = " ";

            Fibonacci fibonacci = new Fibonacci();

            nTermo = Convert.ToInt32(textBoxTermo.Text);

            for (int i = 1; i <= nTermo; i ++)
            {
                label2.Text += fibonacci.Sequecia(i).ToString() + " ";
            }
        }
    }
}
