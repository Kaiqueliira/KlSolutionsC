using KlSolutions.Models;
using Microsoft.AspNetCore.Mvc;

namespace KLSOLUTIONSC.Controllers
{
    public class UsuarioController : Controller
    {
        
        public IActionResult Login(){
            
            return View();

        }

    [HttpPost]
    public IActionResult Login(Usuario usuario){
        UsuarioBD UsuarioBanco = new UsuarioBD();
        Usuario UsuarioEncontrado = UsuarioBanco.FazerLogin(usuario);

        if(UsuarioEncontrado != null){
            return RedirectToAction("Index", "Home");

        }else{
            ViewBag.Mensagem = "Falha No login";
            return View();
        }
    }
    }
    
}