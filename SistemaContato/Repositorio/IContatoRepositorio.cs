using SistemaContato.Controllers;
using SistemaContato.Models;

namespace SistemaContato.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel ListarPorId(int id);
        List<ContatoModel> buscarTodos();

        ContatoModel Adicionar(ContatoModel contato);

    }
}
