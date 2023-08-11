using ControleContatos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ControleContatos.Controllers
{
    public class UsuarioController : Controller
    {
        public UsuarioModel model;
        private readonly Banco banco;
        public GeradorDeContato gerador;

        public UsuarioController(UsuarioModel _model, Banco _banco, GeradorDeContato _gerador)
        {
            model = _model;
            banco = _banco;
            gerador = _gerador;

        }
        public IActionResult Index()
        {
            return View(banco.listaUsuario);
        }
        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            foreach (var item in banco.listaUsuario)
            {
                if (item.Id == id)
                {
                    model = item;
                }
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Alterar(SemSenhaModel model, int id)
        {
            try
            {
               
                if(ModelState.IsValid) 
                {
                    foreach (var item in banco.listaUsuario)
                    {
                        if (item.Id == id)
                        {
                            item.Nome = model.Nome;
                            item.Email = model.Email;
                            item.Login = model.Login;
                            item.Perfil = model.Perfil;                           
                            item.DataAtualizacao = DateTime.Now;
                        }
                    }
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", model);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu contato, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contato.Id = banco.listaUsuario.Count + 1;
                    contato.Nome = contato.Nome;
                    contato.Login = contato.Login;
                    contato.Email = contato.Email;
                    contato.Senha = contato.Senha;
                    contato.DataCadastro = DateTime.Now;
                    banco.listaUsuario.Add(contato);
                    TempData["MensagemSucesso"] = "Usuario cadastrado com sucesso";
                    return RedirectToAction("Index", "Login");
                }

                return View(contato);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu Usuario, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

        public IActionResult ApagarConfirmacao(int id)
        {

            try
            {
                var contato = banco.listaUsuario.FirstOrDefault(c => c.Id == id);
                if (contato != null)
                {
                    banco.listaUsuario.Remove(contato);
                    TempData["MensagemSucesso"] = "Usuario apagado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não foi possível encontrar o Usuario para apagar";
                }

                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu usuario, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
       
    }
}
