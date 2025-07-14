using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculoSalario
{
    public partial class Form1 : Form
    {
        Mensalista m = new Mensalista();
        Aulista a = new Aulista();

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            m.Nome = textBoxNome.Text;
            m.Matricula = textBoxMatricula.Text;

            m.CalcularHoraAtividade(Convert.ToDouble(textBoxSalario));
            textBoxHoraAtvM.Text = (m.HoraAtividade).ToString("N2");

            m.CalcularsalarioMensalista();

            textBoxSalarioTotalM.Text = (m.SalarioTotalMensalista).ToString("N2");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            a.Nome = textBoxNome.Text;
            a.Matricula = (textBoxMatricula.Text);

            a.CalcularSalarioBaseAulista(Convert.ToInt32(textBoxNumeroAulas), Convert.ToDouble(textBoxValorHRAula));

            textBoxSalarioBase.Text = a.SalarioTotalAulista.ToString();

            a.CalcularHoraAtividade(a.SalarioTotalAulista);

            a.CalcularDSR();

            textBoxDSR.Text = (a.DSR).ToString("N2");

            a.CalcularSalarioAulista();

            textBoxSalarioTotalA.Text = (a.SalarioTotalAulista).ToString("N2");

            MessageBox.Show(a.Matricula + " - " + a.Nome + "\nSalário: " +
(a.SalarioTotalAulista).ToString("C2"));
        }
    }
}
