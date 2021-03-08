using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using KlSolutions.Models;


namespace KlSolutions.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            UsuarioBD.TestarConexao();
            return View();
        }
        public IActionResult Servicos()
        {
            return View();
        }

        public IActionResult Contatos()
        {


            return View();
        }
        [HttpPost]
        public IActionResult Contatos(Contato contato)
        {

            ContatoBD contatobd = new ContatoBD();
            contatobd.Cadastrar(contato);
            
            return RedirectToAction("Index");
        }
        
        
       
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
