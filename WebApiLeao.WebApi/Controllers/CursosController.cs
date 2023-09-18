using Microsoft.AspNetCore.Mvc;
using WebApiLeao.Domain.Entities;
using WebApiLeao.Repository.Interface;

namespace WebApiLeao.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly ICursosRepository _cursoRepository;

        public CursosController(ICursosRepository cursosRepository)
        {
            _cursoRepository = cursosRepository;
        }

        [HttpPost("Register")]
        public async  Task<IActionResult> Register(EntityCursos entidadesCursos)
        {
            if(entidadesCursos == null)
            {
                return BadRequest($"{entidadesCursos} não pode ser nulo");
            };

            await _cursoRepository.Insert(entidadesCursos);
            return Ok("Curso registrado com sucesso!");
        }

        [HttpGet("ObterTodosCursos")]
        public async Task<IActionResult> ObterTodosCursos()
        {

            var result = await _cursoRepository.GetAll();
            return Ok(result.ToList());
        }
    }
}
