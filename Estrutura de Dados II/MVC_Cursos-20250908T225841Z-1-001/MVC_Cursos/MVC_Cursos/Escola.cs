using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Cursos
{
    internal class Escola
    {
        public List<Curso> Cursos { get; set; } = new List<Curso>();

        public bool AdicionarCurso(Curso curso)
        {
            if (Cursos.Count < 5 && !Cursos.Contains(curso))
            {
                Cursos.Add(curso);
                return true;
            }
            return false;
        }

        public Curso PesquisarCurso(int cursoId)
        {
            return Cursos.FirstOrDefault(c => c.Id == cursoId);
        }

        public bool RemoverCurso(int cursoId)
        {
            var curso = PesquisarCurso(cursoId);
            if (curso != null && curso.Disciplinas.Count == 0)
            {
                Cursos.Remove(curso);
                return true;
            }
            return false;
        }
    }
}
