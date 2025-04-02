using Api.Configurations;
using Api.ViewModel;
using Data.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/routes")]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IMapper _mapper;

        public ContatoController(IContatoRepository contatoRepository, IMapper mapper)
        {
            _contatoRepository = contatoRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAll", Name = "Retorna todos")]
        public async Task<IEnumerable<ContatoViewModel>> ObterTodods()
        {
            return _mapper.Map<IEnumerable<ContatoViewModel>>(await _contatoRepository.ObterTodos());
        }

        private async Task<ContatoViewModel> ObterContato(int id)
        {
            return _mapper.Map<ContatoViewModel>(await _contatoRepository.ObterPorId(id));
        }

        [HttpGet("{id:int}", Name = "GetPorId")]
        public async Task<ActionResult<ContatoViewModel>> ObterPorId(int id)
        {
            var contatoViewModel = await ObterContato(id);
            if (contatoViewModel == null) return NotFound();

            return contatoViewModel;
        }

        [HttpPost("Criar")]
        public async Task<ActionResult<ContatoViewModel>> Adicionar(ContatoViewModel contatoViewModel)
        {
            var contato = _mapper.Map<Contato>(contatoViewModel);
            await _contatoRepository.Adicionar(contato);
            return contatoViewModel;
        }

        [HttpPut("{id:int}", Name = "Atualizar")]
        public async Task<ActionResult<ContatoViewModel>> Atualizar(int id, ContatoViewModel contatoViewModel)
        {
            if(id != contatoViewModel.Id)
            {
                throw new Exception("Os ids informados são diferentes");
            }

            var contatoAtualizar = await ObterContato(id);

            contatoAtualizar.Id = contatoViewModel.Id;
            contatoAtualizar.Nome  = contatoViewModel.Nome;
            contatoAtualizar.DataNascimento = contatoViewModel.DataNascimento;
            contatoAtualizar.Sexo = contatoViewModel.Sexo;
            contatoAtualizar.Ativo = contatoViewModel.Ativo;

            await _contatoRepository.Atualizar(_mapper.Map<Contato>(contatoAtualizar));
            return contatoAtualizar;
        }

        [HttpDelete("{id:int}", Name = "Excluir")]
        public async Task<ActionResult<ContatoViewModel>> Remover(int id)
        {
            var contatoViewModel = await ObterContato(id);
            if (contatoViewModel == null) return NotFound();

            await _contatoRepository.Remover(id);

            return contatoViewModel;
        }

    }
}
