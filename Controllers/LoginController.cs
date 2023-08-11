using ControleContatos.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleContatos.Controllers
{
    public class LoginController : Controller
    {
        UsuarioModel usuario;
        Banco banco;
        LoginModel login;

        public LoginController(UsuarioModel _usuarioModel, Banco _banco, LoginModel _login)
        {
            usuario = _usuarioModel;
            banco = _banco;
            login = _login;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Entrar(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                foreach(var item in banco.listaUsuario)
                {
                    if (item.Senha == model.Senha && item.Login == model.Login)
                    {
                       return RedirectToAction("Index", "Home");
                    }
                }               
                TempData["MensagemErro"] = "Usuario ou Senha invalidos";
                            
            }
            return View("Index");
        }    

    }
}
