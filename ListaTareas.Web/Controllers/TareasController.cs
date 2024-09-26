using ListaTareas.Entidades;
using ListaTareas.Logica;
using Microsoft.AspNetCore.Mvc;

namespace ListaTareas.Web.Controllers
{
    public class TareasController : Controller
    {
        private readonly ITareaLogica _tareaLogica; 
        public TareasController(ITareaLogica tareaLogica ) {

               _tareaLogica = tareaLogica;
        }
        public IActionResult Index()
        {
            return View(_tareaLogica.ObtenerTareas());
        }

        [HttpGet]
        public IActionResult Agregar()
        {
          
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Tarea tarea)
        {
            if (!ModelState.IsValid)
                return View(tarea);

            _tareaLogica.AgregarTarea(tarea);

           return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int idTarea)
        {
            _tareaLogica.EliminarTarea(idTarea);
            return RedirectToAction("Index");
        }

        public IActionResult Completar(int idTarea)
        {
            _tareaLogica.CompletarTarea(idTarea);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int idTarea)
        {
            var tarea = _tareaLogica.ObtenerTareaPorId(idTarea);
            if (tarea == null)
            {
                return NotFound();
            }

            return View(tarea);  
        }

        [HttpPost]
        public IActionResult Editar(Tarea tarea)
        {
            if (!ModelState.IsValid)
                return View(tarea);

            _tareaLogica.EditarTarea(tarea);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ToggleCompletada(int idTarea)
        {
            var tarea = _tareaLogica.ObtenerTareaPorId(idTarea);
            if (tarea == null)
            {
                return NotFound();
            }

          
            tarea.Completada = !tarea.Completada;

            return Ok();
        }
    }
}
