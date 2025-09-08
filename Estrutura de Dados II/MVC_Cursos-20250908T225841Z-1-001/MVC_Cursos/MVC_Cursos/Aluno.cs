using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Cursos
{
    internal class Aluno
    {
        public int id { get; set; }
        public string nome { get; set; }


        public bool podeMatricular(Curso curso)
        {
            int disciplinasMatriculadas = curso.Disciplinas
                .Count(d => d.Alunos.Contains(this));

            return disciplinasMatriculadas < 6;
        }
    }
}
