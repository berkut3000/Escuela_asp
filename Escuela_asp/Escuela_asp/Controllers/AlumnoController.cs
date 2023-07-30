using Escuela_asp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Escuela_asp.Controllers
{
    public class AlumnoController : Controller
    {
        [Route("[controller]")]
        //[Route("Alumno/Index")]
        [Route("Alumno/Index/{id}")]
        //[Route("Alumno/{id}")]
        public IActionResult Index(string? id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var alumno = from alumn in _context.Alumnos
                             where alumn.Id == id
                             select alumn;
                return View(alumno.SingleOrDefault());
            }
            else
            {
                return View("Multialumno", _context.Alumnos);
            }
        }
        public IActionResult Multialumno()
        {
            return View("Multialumno", _context.Alumnos);
        }

        private EscuelaContext _context;
        public AlumnoController(EscuelaContext context)
        {
            _context = context;
        }

    }
}
