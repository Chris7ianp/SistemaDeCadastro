using MeuSiteEmMVC.Models;
using MeuSiteEmMVC.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace MeuSiteEmMVC.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRespositorio _contatoRepositorio;
        public ContatoController(IContatoRespositorio contatoRespositorio)
        {
            _contatoRepositorio = contatoRespositorio;
        }
    
        public IActionResult Index()
        {
            List<ContatoModel> contato = _contatoRepositorio.BuscarTodos();
            return View(contato);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _contatoRepositorio.BuscarTodos();
        }

            // Edição //

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _contatoRepositorio.Apagar(id);
                    if (apagado){
                        TempData["MensagemSucesso"] = "Contato apagado com sucesso!";
                    }
                    else{
                        TempData["MensagemSucesso"] = "Ops! Não conseguimos apagar seu contato!";
                    }

                    return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops! Não conseguimos apagar seu contato, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try{
                if(ModelState.IsValid)
            {
                _contatoRepositorio.Adicionar(contato);
                TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";
                return RedirectToAction("Index");
            }

                return View(contato);

            }

            catch (System.Exception erro)
                {
                    TempData["MensagemErro"] = $"Ops! Não conseguimos cadastrar seu contato, tente novamente, detalhe do erro: {erro.Message}";
                    return RedirectToAction("Index");
                }

        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
           try
           {
                if(ModelState.IsValid)
                {
                _contatoRepositorio.Atualizar(contato);
                TempData["MensagemSucesso"] = "Contato alterado com sucesso";
                return RedirectToAction("Index");
                }
           
                return View("Editar", contato);
           }

           catch (System.Exception erro)
           {
                TempData["MensagemErro"] = $"Ops! Não conseguimos altualizar seu contato, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");   
           }
        }
    }
}
