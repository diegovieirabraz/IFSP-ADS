using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exame
{
    internal class Classificacao
    {
        public double exameI;
        public double exameII;
        public double exameIII;
        public double exameIV;
        public double exameV;

        public string CalculoNota()
        {
            bool passou1 = exameI >= 70;
            bool passou2 = exameII >= 70;
            bool passou3 = exameIII >= 70;
            bool passou4 = exameIV >= 70;
            bool passou5 = exameV >= 70;

            if (passou1 && passou2 && passou3 && passou4 && passou5)
            {
                return "Passou em todos os exames";
            }
            else if (passou1 && passou2 && !passou3 && passou4 || !passou5)
            {
                return "Passou em I, II, IV, mas não em III ou V";
            }
            else if (passou1 && passou2 && passou3 && passou4 && !passou5)
            {
                return "Passou em I, II, III, IV, mas não em V";
            }
            else
            {
                return "Não Passou no exame";
            }
        }

    }
}
