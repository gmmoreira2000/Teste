using Domain;

namespace Data.Repository.Interfaces
{
    public interface IContatoRepository : IDisposable
    {
        Task Adicionar(Contato contato);
        Task<Contato> ObterPorId(int id);
        Task<List<Contato>> ObterTodos();
        Task Atualizar(Contato contato);
        Task Remover(int id);
        Task<int> SaveChanges();
    }
}
