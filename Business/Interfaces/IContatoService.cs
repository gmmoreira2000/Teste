using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    }
}
