using Microsoft.AspNetCore.Mvc;
using WebLeao.WebApplication.Models;

namespace WebLeao.WebApplication.Controllers
{
    public class CursosController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListaCursos()
        {
            return View();
        }

        //public async Task<IEnumerable<CursosViewModel>> GetCursos()
        //{
        //    using(HttpClient httpClient = new HttpClient())
        //    {

        //    }
        //}
    }
}
