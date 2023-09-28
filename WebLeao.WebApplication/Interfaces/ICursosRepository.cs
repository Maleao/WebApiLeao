using Microsoft.AspNetCore.Mvc;
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


    }
}
