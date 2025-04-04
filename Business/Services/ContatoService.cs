using AutoMapper;
using Business.DTOs;
using Business.Interfaces;
using Business.ViewModels;
using Data.Repository.Interfaces;
using Domain;

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
        public async Task Atualizar(ContatoDTO contatoViewModel)
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

        public async Task<ContatoDTO> ObterPorIdAtivo(int id)
        {
            try
            {
                var contato = await _contatoRepository.ObterPorId(id);
                if (contato == null) throw new Exception("Este contato não existe!");
                if(!contato.Ativo) throw new Exception("Este contato não pode ser retornado, pois ele está inativo!");
                return _mapper.Map<ContatoDTO>(contato);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ContatoDTO> ObterPorId(int id)
        {
            
                var contato = await _contatoRepository.ObterPorId(id);
                if (contato == null) throw new Exception("Este contato não existe!");
                return _mapper.Map<ContatoDTO>(contato);
            
        }


        public async Task<List<ContatoDTO>> ObterTodos()
        {
            var contato = await _contatoRepository.ObterTodos();
            return _mapper.Map<List<ContatoDTO>>(contato);
        }

        public async Task Desativar(ContatoDTO contatoDto)
        {
            contatoDto.Ativo = false;
            await _contatoRepository.Atualizar(_mapper.Map<Contato>(contatoDto));
        }

        public void Dispose()
        {
            _contatoRepository?.Dispose();
        }
    }
}
