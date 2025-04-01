using Api.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/routes")]
    public class ContatoController : Controller
    {
        public ContatoController() { }

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
