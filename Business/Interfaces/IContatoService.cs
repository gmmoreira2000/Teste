using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Business.Interfaces
{
    public interface IContatoService : IDisposable
    {
        public Task Adicionar(Contato contato);
        public Task Atualizar(Contato contato);
        public Task Remover(int id);

    }
}
