using Business.DTOs;
using Business.Interfaces;
using Business.ViewModels;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("GetAll")]
        public async Task<IEnumerable<ContatoDTO>> ObterTodods()
        {
            return await _contatoService.ObterTodos();
        }

        private async Task<ContatoDTO> ObterContato(int id)
        {
            return await _contatoService.ObterPorIdAtivo(id);
        }

        [HttpGet("GetPorID")]
        public async Task<ActionResult<ContatoDTO>> ObterPorId(int id)
        {
            var contatoViewModel = await ObterContato(id);
            if (contatoViewModel == null) return NotFound();
            if (!contatoViewModel.Ativo) throw new Exception("Contato está invativo!");

            return contatoViewModel;
        }

        [HttpPost("Criar")]
        public async Task<ActionResult<ContatoViewModel>> Adicionar(ContatoViewModel contatoViewModel)
        {
            await _contatoService.Adicionar(contatoViewModel);
            return contatoViewModel;
        }

        [HttpPut("Atualizar")]
        public async Task<ActionResult<ContatoDTO>> Atualizar(int id, ContatoViewModel contatoViewModel)
        {

            var contatoAtualizar = await ObterContato(id);

            contatoAtualizar.Nome  = contatoViewModel.Nome;
            contatoAtualizar.DataNascimento = contatoViewModel.DataNascimento;
            contatoAtualizar.Sexo = contatoViewModel.Sexo;

            await _contatoService.Atualizar(contatoAtualizar);
            return contatoAtualizar;
        }

        [HttpDelete("Excluir")]
        public async Task<ActionResult<ContatoDTO>> Remover(int id)
        {
            var contatoViewModel = await _contatoService.ObterPorId(id);
            if (contatoViewModel == null) return NotFound();

            await _contatoService.Remover(id);

            return contatoViewModel;
        }

        [HttpPatch("DesativarContato")]
        public async Task<ActionResult<ContatoDTO>> DesativarContato(int id)
        {
            var contatoViewModel = await ObterContato(id);
            if (contatoViewModel == null) return NotFound();

            await _contatoService.Desativar(contatoViewModel);

            return contatoViewModel;
        }

    }
}
