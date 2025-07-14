using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projetoabstract
{
    internal abstract class Forma
    {
        private double area;
        private double cor;
        private double perimetro;

        public double Area
        {
            get { return area; }
            set { area = value; }
        }

        // Propriedade para 'cor'
        public double Cor
        {
            get { return cor; }
            set { cor = value; }
        }

        // Propriedade para 'perimetro'
        public double Perimetro
        {
            get { return perimetro; }
            set { perimetro = value; }
        }

        public abstract void CalcularArea();
        public abstract void CalcularPerimetro();
        public string descricao()
        {
            return "Classe abstrata Forma";
        }
    }

}
