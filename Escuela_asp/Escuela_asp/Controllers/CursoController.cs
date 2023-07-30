using Escuela_asp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Escuela_asp.Controllers
{
    public class CursoController : Controller
    {
        [Route("[controller]")]
        [Route("Curso/Index")]
        [Route("Curso/Index/{id}")]
        [Route("Curso/{id}")]
        public IActionResult Index(string? id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var Curso = from curs in _context.Cursos
                             where curs.Id == id
                             select curs;
                return View(Curso.SingleOrDefault());
            }
            else
            {
                return View("MultiCurso", _context.Cursos);
            }
        }
        public IActionResult MultiCurso()
        {
            return View("MultiCurso", _context.Cursos);
        }

        private EscuelaContext _context;
        public CursoController(EscuelaContext context)
        {
            _context = context;
        }

    }
}
