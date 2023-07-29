using Escuela_asp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Escuela_asp.Controllers
{
    public class AsignaturaController : Controller
    {
        [Route("[controller]")]
        [Route("Asignatura/Index")]
        public IActionResult Index()
        {
            return View("Multiasignatura", _context.Asignaturas);
        }
        [Route("Asignatura/Index/{asignaturaId}")]
        public IActionResult Index(string asignaturaId)
        {
            var asignatura = from asig in _context.Asignaturas where asig.Id == asignaturaId select asig;
            return View(asignatura.SingleOrDefault());
        }

        public IActionResult Multiasignatura()
        {
            ViewBag.CosaDinamica = "La Monja";
            ViewBag.Fecha = DateTime.UtcNow;

            return View("Multiasignatura", _context.Asignaturas);
        }

        private EscuelaContext _context;
        public AsignaturaController(EscuelaContext context)
        {
            _context = context;
        }

    }
}
