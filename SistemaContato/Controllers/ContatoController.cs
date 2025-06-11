using Microsoft.AspNetCore.Mvc;
using SistemaContato.Models;
using SistemaContato.Repositorio;

namespace SistemaContato.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
            
        }

        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.buscarTodos();
            return View(contatos);
        }
        [HttpGet]public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            ContatoModel contato =_contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult ExcluirConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }
        [HttpGet]
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _contatoRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MenssagemSucesso"] = "Contato excluído com sucesso!";
                }
                else
                {
                    TempData["MenssagemErro"] = "Ops, não foi possivel excluir o contato!";
                }

                return RedirectToAction("Index");
            }
            catch(System.Exception erro)
            {
                TempData["MenssagemErro"] = $"Não foi possivel excluir o contato. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
            
        }

        [HttpPost]public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MenssagemSucesso"] = "Contato cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (System.Exception erro)
            {
                    TempData["MenssagemErro"] = $"Ops, não conseguimos cadastrar seu contato, tente novamente. Detalhe do erro:{erro.Message}";
                    return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MenssagemSucesso"] = "Contato atualizado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", contato);
            }
            catch (System.Exception erro)
            {
                TempData["MenssagemErro"] = $"Ops, não conseguimos atualizar seu contato, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
