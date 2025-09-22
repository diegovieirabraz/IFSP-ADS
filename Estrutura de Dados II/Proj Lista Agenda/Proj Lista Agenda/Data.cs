using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Proj_Lista_Agenda
{
    internal class Data 
    {
        private int dia;
        private int mes;
        private int ano;

          public int Dia
        {
            get { return dia; }
            set { dia = value; }
        }

        public int Mes
        {
            get { return mes; }
            set { mes = value; }
        }

        public int Ano
        {
            get { return ano; }
            set { ano = value; }
        }

        public Data()
        {
        }

        public Data(int dia, int mes, int ano)
        {
            this.dia = dia;
            this.mes = mes;
            this.ano = ano;
        }

        public void setData(int dia, int mes, int ano)
        {
            this.dia = dia;
            this.mes = mes;
            this.ano = ano;
        }

        public override string ToString()
        {          
            return $"{this.dia:D2}/{this.mes:D2}/{this.ano:D4}";
        }

    }
}
