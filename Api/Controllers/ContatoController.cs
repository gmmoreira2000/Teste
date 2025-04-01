using Api.Configurations;
using Api.ViewModel;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using AutoMapper;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/routes")]
    public class ContatoController : Controller
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IMapper _mapper;
       
        public ContatoController(IContatoRepository contatoRepository, IMapper mapper) 
        { 
            _contatoRepository = contatoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ContatoViewModel>> ObterTodods()
        {
            return _mapper.Map<IEnumerable<ContatoViewModel>> (await _contatoRepository.ObterTodos());
        }

        [HttpGet{"{id:id}"]
        public async Task<ActionResult<ContatoViewModel>> ObterPorId(int id)
        {
            var contatoViewModel = await ObterPorId(id);
            if (contatoViewModel == null) return NotFound();

            return contatoViewModel;
        }

        [HttpPost]
        public async Task<ActionResult<ContatoViewModel>> Adicionar(ContatoViewModel contatoViewModel) 
        {
            
        }

        [HttpPut]
        public async Task<ActionResult<ContatoViewModel>> Atualizar()
        {

        }

        [HttpDelete]
        public async Task<ActionResult<ContatoViewModel>> Remover()
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
