using Escuela_asp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Escuela_asp.Controllers
{
    public class AsignaturaController : Controller
    {
        [Route("Asignatura/Index")]
        [Route("Asignatura/Index/{asignaturaId}")]

        public IActionResult Index(string asignaturaId)
        {
            if(!string.IsNullOrEmpty(asignaturaId))
            {
                var asignatura = from asig in _context.Asignaturas
                                 where asig.Id == asignaturaId
                                 select asig;
                return View(asignatura.SingleOrDefault());
            }
            else
            {
                return View("Multiasignatura", _context.Asignaturas);
            }
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
