using Business.ViewModels;

namespace Business.Interfaces
{
    public interface IContatoService : IDisposable
    {
        public Task Adicionar(ContatoViewModel contatoViewModel);
        public Task Atualizar(ContatoViewModel contatoViewModel);
        public Task Remover(int id);
        public Task<ContatoViewModel> ObterPorId(int id);
        public Task<List<ContatoViewModel>> ObterTodos();
        public Task Desativar(ContatoViewModel contatoViewModel);

    }
}
