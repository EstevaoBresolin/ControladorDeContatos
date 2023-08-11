using ControleContatos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ControleContatos.Controllers
{
    public class ContatoController : Controller
    {
        public  ContatoModel model;
        private readonly Banco banco;
        public GeradorDeContato gerador;

        public ContatoController(ContatoModel _model, Banco _banco,GeradorDeContato _gerador)
        {
            model = _model;
            banco = _banco;
            gerador = _gerador;
           
        }
        

        public IActionResult Index()
        {
            return View(banco.lista);
        }
       
        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            
            foreach (var item in banco.lista)
            {
                if (item.Id == id)
                {
                    model = item;
                }
            }
            return View(model);
           
        }
        [HttpPost]
        public IActionResult Alterar (ContatoModel model, int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    foreach (var item in banco.lista)
                    {
                        if (item.Id == id)
                        {
                            item.Nome = model.Nome;
                            item.Celular = model.Celular;
                            item.Email = model.Email;
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
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contato.Id = banco.lista.Count +1;
                    contato.Nome = contato.Nome;
                    contato.Celular = contato.Celular;
                    contato.Email = contato.Email;
                    banco.lista.Add(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu contato, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
            
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            
            try
            {               
                var contato = banco.lista.FirstOrDefault(c => c.Id == id);
                if (contato != null)
                {
                    banco.lista.Remove(contato);                   
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não foi possível encontrar o contato para apagar";
                }
                
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu contato, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult AdicionarContatos(ContatoModel contato)
        {
            contato.Id = banco.lista.Count +1;
            contato.Nome = gerador.GerarNome();
            string email = contato.Nome.Replace(" ", "") + "@gmail.com";
            contato.Email = email;
            contato.Celular = gerador.GerarNumero();
            banco.lista.Add(contato);
            return RedirectToAction("Index");
            
        }

       
    }
}
