using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Servicios;
using System.Diagnostics;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IRepositorioProyectos repositorioProyectos;

        public HomeController(IRepositorioProyectos repositorioProyectos)
        {
            this.repositorioProyectos = repositorioProyectos;

        }

        public IActionResult Index()
        {
            var proyectos = repositorioProyectos.ObtenerProyectos().Take(3).ToList(); // crea una variable de proyectos y la llena con el método creado para los proyectos,
                                                                                      // los lista tomando solo 3.
            var modelo = new HomeIndexViewModel()
            {
                Proyectos = proyectos,
            }; //crea un modelo de tipo homeindexvm al cual le asigna los proyectos
            return View(modelo);
        }
        
        public IActionResult Proyectos() 
        {
            var proyectos = repositorioProyectos.ObtenerProyectos();

            return View(proyectos);
        }

        public IActionResult Contacto()
        {
            return View();
        }

        [HttpPost] //Atributo, (Por defecto tienen HttpGet), estamos indicando que la acción siguiente se va a ejecutar cuando recibamos un HttpPost
        public IActionResult Contacto(ContactoViewModel contactoViewModel)
        {
            return RedirectToAction("Gracias");
        }

        public IActionResult Gracias() 
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}