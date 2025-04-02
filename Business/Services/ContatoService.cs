using Business.Interfaces;
using Domain;
using Data.Repository.Interfaces;
using Business.ViewModels;
using AutoMapper;

namespace Business.Services
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IMapper _mapper;

        public ContatoService(IContatoRepository contatoRepository, IMapper mapper)
        {
            _contatoRepository = contatoRepository;
            _mapper = mapper;
        }
        public async Task Adicionar(ContatoViewModel contatoViewModel)
        {
            try
            {
                await _contatoRepository.Adicionar(_mapper.Map<Contato>(contatoViewModel));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task Atualizar(ContatoViewModel contatoViewModel)
        {
            await _contatoRepository.Atualizar(_mapper.Map<Contato>(contatoViewModel));
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

        public async Task<ContatoViewModel> ObterPorId(int id)
        {
            var contato = await _contatoRepository.ObterPorId(id);
            return _mapper.Map<ContatoViewModel>(contato);
        }

        public async Task<List<ContatoViewModel>> ObterTodos()
        {
            var contato = await _contatoRepository.ObterTodos();
            return _mapper.Map<List<ContatoViewModel>>(contato);
        }
      
        public void Dispose()
        {
            _contatoRepository?.Dispose();
        }
    }
}
