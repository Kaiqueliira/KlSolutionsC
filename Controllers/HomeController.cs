using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult Cadastro(Usuario user)
        {   
            Usuario u = new Usuario();
            u.Login = user.Login;
            u.Senha = user.Senha;

            Console.Write(u.Login +" "+ u.Senha);
            return View("Login");
        }


        [HttpPost]
        public IActionResult Login(Usuario user)
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
