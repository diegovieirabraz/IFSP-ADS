using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Cursos
{
    internal class Curso
    {
        public string Id {  get; set; }
        public string Descricao { get; set; }
        public List<Disciplina> Disciplinas { get; set; } new List<Disciplina>();

        public bool adicionarDisciplina(Disciplina disciplina)
        {
            if (Disciplinas.Count < 12 && Disciplinas.Contains(disciplina))
            {
                Disciplinas.Add(disciplina);
            }
            return true;
        }

        public Disciplina pesquisarDisciplina(Disciplina disciplina)
        {
            return  Disciplinas.FirstOrDefault(d => d.Descricao  == disciplina.Descricao);
        }
        public bool removerDisciplina(Disciplina disciplina)
        {
            if (Disciplinas.Contains(disciplina))
            {
                Disciplinas.Remove(disciplina);
                return true;
            }

            return false;
        }
    }
}
