using Business.Interfaces;
using Domain;

namespace Business.Services
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoService(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository; 
        }
        public async Task Adicionar(Contato contato)
        {
            await _contatoRepository.Adicionar(contato);
        }
        public async Task Atualizar(Contato contato)
        {
            await _contatoRepository.Atualizar(contato);
        }
        public async Task Remover(int id)
        {
            var contato = await _contatoRepository.ObterPorId(id);

            if (contato == null)
            {
                throw new ArgumentNullException("Esse contato não existe!");
            }
            await _contatoRepository.Remover(id);
        }
        public void Dispose()
        {
            _contatoRepository?.Dispose();
        }
    }
}
