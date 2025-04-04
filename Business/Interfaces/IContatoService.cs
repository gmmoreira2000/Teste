using Business.ViewModels;
using Business.DTOs;

namespace Business.Interfaces
{
    public interface IContatoService : IDisposable
    {
        public Task Adicionar(ContatoViewModel contatoViewModel);
        public Task Atualizar(ContatoDTO contatoViewModel);
        public Task Remover(int id);
        public  Task<ContatoDTO> ObterPorIdAtivo(int id);
        public Task<ContatoDTO> ObterPorId(int id);
        public Task<List<ContatoDTO>> ObterTodos();
        public Task Desativar(ContatoDTO contatoDto);

    }
}
