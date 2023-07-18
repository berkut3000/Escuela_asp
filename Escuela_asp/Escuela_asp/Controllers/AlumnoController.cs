using Escuela_asp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Escuela_asp.Controllers
{
    public class AlumnoController : Controller
    {
        public IActionResult Index()
        {
            return View(_context.Alumnos.FirstOrDefault());
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
