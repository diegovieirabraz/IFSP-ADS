using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projetoabstract
{
    public partial class Form1 : Form
    {       
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string formaSelecionada = comboBox1.SelectedItem.ToString();

            if (formaSelecionada == "Quadrado")
            {
                Quadrado q = new Quadrado();
                q.Lado = Convert.ToInt32(textBoxQuadrado.Text);
                q.CalcularArea();
                q.CalcularPerimetro();

                labelArea.Text = "A área do quadrado é " + q.Area + " metro(s) quadrado(s)";
                labelPerimetro.Text = " o perímetro do qusdrado é " + q.Perimetro + " metr(s)";
            }

            else if (formaSelecionada == "Triangulo")
            {
                Triangulo t = new Triangulo();
                t.BaseT = Convert.ToDouble(textBoxBaseT.Text);
                t.Altura = Convert.ToDouble(textBoxAlturaT.Text);
                t.LadoA = Convert.ToDouble(textBoxLadoA.Text);
                t.LadoB = Convert.ToDouble(textBoxLadoB.Text);
                t.LadoC = Convert.ToDouble(textBoxLadoC.Text);
                t.CalcularArea();
                t.CalcularPerimetro();

                labelArea.Text = $"Área: {t.Area} metros quadrados";
                labelPerimetro.Text = $"Perímetro: {t.Perimetro} metros";
            }
            else if(formaSelecionada == "Retangulo")
            {
                Retangulo r = new Retangulo();
                r.Base = Convert.ToDouble(textBoxBaseR.Text);
                r.Altura = Convert.ToDouble(textBoxAlturaR.Text);
                r.CalcularArea();
                r.CalcularPerimetro();

                labelArea.Text = $"Área: {r.Area} metros quadrados";
                labelPerimetro.Text = $"Perímetro: {r.Perimetro} metros";
            }
        }
    }
}
