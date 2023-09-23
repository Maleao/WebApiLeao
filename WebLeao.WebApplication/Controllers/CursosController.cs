using Microsoft.AspNetCore.Mvc;
using WebLeao.WebApplication.Models;
using WebLeao.WebApplication.EnumVerbs;
using Newtonsoft.Json;

namespace WebLeao.WebApplication.Controllers
{
    public class CursosController : Controller
    {
        readonly string _apiUri;
        private readonly IConfiguration _config;

        public CursosController(IConfiguration config)
        {
            _config = config;
            _apiUri = _config.GetValue<string>("Uri");
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ListaCursos()
        {
            return View(await GetCursos());
        }

        public async Task<IEnumerable<CursosViewModel>?> GetCursos()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var cursos = new CursosViewModel();

                HttpResponseMessage response = await httpClient.GetAsync(_apiUri + enumActions.ObterTodosCursos);
                if(response.IsSuccessStatusCode)
                {
                    var dados = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IEnumerable<CursosViewModel>>(dados);

                }

                return new List<CursosViewModel>();
            }
        }
    }
}
