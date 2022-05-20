using Microsoft.AspNetCore.Mvc;
using Pessoas.Models;
using Pessoas.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pessoas.Controllers
{
    public class PessoasController : Controller
    {
        private readonly IPessoaRepositorio _pessoaRepositorio;
        public PessoasController(IPessoaRepositorio pessoaRepositorio)
        {
            _pessoaRepositorio = pessoaRepositorio;
        }
        public IActionResult Index()
        {
            List<PessoasModel> pessoas = _pessoaRepositorio.BuscarTodos();
            return View(pessoas);
        }
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(PessoasModel pessoas)
        {
            try
            {
                if(ModelState.IsValid)
                {
                 
                    _pessoaRepositorio.Adicionar(pessoas);
                    TempData["MensagemSucesso"] = "Pessoa cadastrada com sucesso";
                    return RedirectToAction("Index");
                }
                return View(pessoas);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Erro, não conseguimos cadastrar a Pessoa, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Editar(int Id)
        {
            PessoasModel pessoas= _pessoaRepositorio.ListarPorId(Id);
            return View(pessoas);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            PessoasModel pessoas = _pessoaRepositorio.ListarPorId(id);
            return View(pessoas);
        }

        public IActionResult Apagar(int Id)
        {
            try
            {
                bool apag = _pessoaRepositorio.Apagar(Id);


                if (apag)
                {
                    TempData["MensagemSucesso"] = "Pessoa deletada com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos deletar a Pessoa, tente novamente";
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Ops, não conseguimos deletar a Pessoa, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Alterar(PessoasModel pessoas)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _pessoaRepositorio.Atualizar(pessoas);
                    TempData["MensagemSucesso"] = "Pessoa Alterada com Sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", pessoas);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos Alterar a Pessoa, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }
    }
}
