using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using KlSolutions.Models;
using KLSOLUTIONSC.Models;

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
        public IActionResult Login()
        {

            return View();
        }
        public IActionResult Cadastro()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Login(Usuario user)
        {   
            if(user.Login == "admin" && user.Senha == "123"){
                
                return View("Index");
            }
            
            return View("Login");
        }


       
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
