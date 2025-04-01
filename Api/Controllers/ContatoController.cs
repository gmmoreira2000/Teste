using Api.Configurations;
using Api.ViewModel;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/routes")]
    public class ContatoController : Controller
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly MapeadorContatoViewModel _mapeador;
        public ContatoController(IContatoRepository contatoRepository, MapeadorContatoViewModel mapeador) 
        { 
            _contatoRepository = contatoRepository;
            _mapeador = mapeador;
        }

        [HttpGet]
        public async Task<IEnumerable<ContatoViewModel>> ObterTodods()
        {
            
        }

        [HttpGet{"{id:id}"]
        public async Task<ActionResult<ContatoViewModel>> ObterPorId(int id)
        {

        }

        [HttpPost]
        public async Task<ActionResult<ContatoViewModel>> Adicionar() 
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
