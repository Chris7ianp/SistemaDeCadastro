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
            _contatoRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            _contatoRepositorio.Adicionar(contato);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            _contatoRepositorio.Atualizar(contato);
            return RedirectToAction("Index");
        }
    }
}
