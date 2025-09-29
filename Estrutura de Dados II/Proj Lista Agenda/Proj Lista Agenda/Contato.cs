using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_Lista_Agenda
{
    internal class Contato
    {
        
        private List<Telefone> telefones;
        
        public string Email { get; set; }
        public string Nome { get; set; }
        public Data DtNasc { get; set; }

        public Contato()
        {
            // Inicializa a lista para evitar erros de referência nula
            this.telefones = new List<Telefone>();
            this.DtNasc = new Data();
        }

        public Contato(string email)
        {
            this.Email = email;
            this.telefones = new List<Telefone>();
            this.DtNasc = new Data();
        }

        public int getIdade()
        {
            DateTime hoje = DateTime.Today;
            int idade = hoje.Year - DtNasc.Ano;

            if (hoje.Month < DtNasc.Mes || (hoje.Month == DtNasc.Mes && hoje.Day < DtNasc.Dia))
            {
                idade--;
            }
            return idade;
        }

        public void adicionarTelefone(Telefone t)
        {
            this.telefones.Add(t);
        }

        public string getTelefonePrincipal()
        {
            foreach (Telefone tel in telefones)
            {
                if (tel.Principal)
                {
                    return $"{tel.Tipo}: {tel.Numero}";
                }
            }
            return "Nenhum telefone principal cadastrado.";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nome: {Nome}");
            sb.AppendLine($"Email: {Email}");
            sb.AppendLine($"Data de Nascimento: {DtNasc.ToString()}");
            sb.AppendLine($"Idade: {getIdade()} anos");
            sb.AppendLine($"Telefone Principal: {getTelefonePrincipal()}");
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Contato outro = (Contato)obj;
            // A unicidade do contato será definida pelo email
            return this.Email.Equals(outro.Email, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            return Email != null ? Email.GetHashCode() : 0;
        }
    }
}
