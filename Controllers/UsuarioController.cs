using KlSolutions.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KLSOLUTIONSC.Controllers
{
    public class UsuarioController : Controller
    {

        public IActionResult Login()
        {

            return View();

        }

        public IActionResult Cadastro(){
            
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Usuario user)
        {
            UsuarioBD userBD = new UsuarioBD();

            userBD.Cadastrar(user);



            return RedirectToAction("Login", "Usuario");

        }

       
        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            UsuarioBD UsuarioBanco = new UsuarioBD();
            Usuario UsuarioEncontrado = UsuarioBanco.FazerLogin(usuario);

            if (UsuarioEncontrado != null)
            {
                HttpContext.Session.SetInt32("IdUsuario", UsuarioEncontrado.Id);
                HttpContext.Session.SetString("NomeUsuario", UsuarioEncontrado.Nome);
                return RedirectToAction("Sistema", "Usuario");

            }
            else
            {
                ViewBag.Mensagem = "Falha No login";
                return View();
            }
        }

        public IActionResult Sistema()
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == null)
            {

                return RedirectToAction("Login", "Usuario");
            }


            return View();

        }
    }

}