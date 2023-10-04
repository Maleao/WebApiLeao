using Refit;
using WebLeao.WebApplication.Models;

namespace WebLeao.WebApplication.Interfaces
{
    public interface ICursosRepository
    {
        [Post("/api/v1/Cursos/Register")]
        Task Registrar(CursosViewModel mod);

        [Get("/api/v1/Cursos/ObterTodosCursos")]
        Task<IEnumerable<CursosViewModel>> ObterCursos();

        [Delete("/api/v1/Cursos/Delete/{Id}")]
        Task Delete(int Id);

        [Get("/api/v1/Cursos/ObterCursoPorId/{Id}")]
        Task<CursosViewModel> ObterCursosPorId(int Id);

        [Put("/api/v1/Cursos/Update/{Id}")]
        Task Update(int Id, CursosViewModel mod);

    }
}
