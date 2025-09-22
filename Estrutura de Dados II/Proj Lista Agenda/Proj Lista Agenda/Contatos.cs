using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_Lista_Agenda
{
    internal class Contatos
    {
        private List<Contato> agenda;

        // Propriedade ReadOnly (só permite a leitura da lista)
        public List<Contato> Agenda
        {
            get { return agenda; }
        }

        // Construtor
        public Contatos()
        {
            this.agenda = new List<Contato>();
        }

        // Métodos
        public bool adicionar(Contato c)
        {
            if (agenda.Contains(c))
            {
                return false; // Contato já existe
            }
            agenda.Add(c);
            return true;
        }

        public Contato pesquisar(Contato c)
        {
            return agenda.FirstOrDefault(contato => contato.Equals(c));
        }

        public bool alterar(Contato c)
        {
            int index = agenda.IndexOf(c);

            if (index != -1)
            {
                agenda[index].Nome = c.Nome;
                agenda[index].DtNasc = c.DtNasc;
                return true;
            }
            return false;
        }

        public bool remover(Contato c)
        {
            return agenda.Remove(c);
        }
    }
}
