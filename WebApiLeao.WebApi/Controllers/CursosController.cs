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
        public async Task<IActionResult> Register(EntityCursos entidadesCursos)
        {
            if (entidadesCursos == null)
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

        [HttpGet("ObterCursoPorId/{Id}")]
        public async Task<IActionResult> ObterCursoPorId(int Id)
        {

            var result = await _cursoRepository.GetById(Id);
            if (result == null)
            {
                return NotFound($"{Id}, não encontrado");
            }

            return Ok(result);
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {

            var result = await _cursoRepository.GetById(Id);
            if (result == null)
            {
                return NotFound($"{Id}, não encontrado");
            }

            await _cursoRepository.Delete(Id);
            return Ok($"{Id}, excluído com sucesso");
        }
    }
}
