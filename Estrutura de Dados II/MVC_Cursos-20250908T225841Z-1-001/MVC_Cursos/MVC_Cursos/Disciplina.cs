using GerenciamentoEscolar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Cursos
{
    internal class Disciplina
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public List<Aluno> Alunos { get; set; } = new List<Aluno>();


        public  bool matriculaAluno(Aluno aluno)
        {
            if (Alunos.Count < 15 && !Alunos.Contains(aluno))
            {
                Alunos.Add(aluno);
            }
            return true;
        }

        public bool desmatricularAluno(Aluno aluno)
        {
            if (Alunos.Contains(aluno))
            {
                return Alunos.Remove(aluno);
            }
            return false;
    
        }
    }
}
