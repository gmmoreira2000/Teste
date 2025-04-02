using Api.Configurations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore;
using Business.Interfaces;
using Business.Services;
using Business.ViewModels;

namespace Api.Controllers
{
    [ApiController]
    [Route("controller")]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoService _contatoService;

        public ContatoController(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        [HttpGet("GetAll", Name = "Retorna todos")]
        public async Task<IEnumerable<ContatoViewModel>> ObterTodods()
        {
            return await _contatoService.ObterTodos();
        }

        private async Task<ContatoViewModel> ObterContato(int id)
        {
            return await _contatoService.ObterPorId(id);
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
            await _contatoService.Adicionar(contatoViewModel);
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

            await _contatoService.Atualizar(contatoAtualizar);
            return contatoAtualizar;
        }

        [HttpDelete("{id:int}", Name = "Excluir")]
        public async Task<ActionResult<ContatoViewModel>> Remover(int id)
        {
            var contatoViewModel = await ObterContato(id);
            if (contatoViewModel == null) return NotFound();

            await _contatoService.Remover(id);

            return contatoViewModel;
        }

    }
}
