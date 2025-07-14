using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoSalario
{
    internal class Professor
    {

        protected string nome;
        protected string matricula;
        protected double salarioBase;
        protected double horaAtividade;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public string Matricula
        {
            get { return matricula; }
            set { matricula = value; }
        }
        public double HoraAtividade
        {
            get { return horaAtividade; }
        }
        public double SalarioBase
        {
            get { return salarioBase; }
        }

        public void CalcularHoraAtividade(double salarioprofessor)
        {
            salarioBase = salarioprofessor;
            horaAtividade = salarioBase * 0.05;
        }
    }
}
