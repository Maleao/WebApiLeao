using Microsoft.AspNetCore.Mvc;
using WebLeao.WebApplication.Models;
using WebLeao.WebApplication.EnumVerbs;
using Newtonsoft.Json;
using System.Text;
using System.Net;

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

        [HttpPost]
        public async Task<IActionResult> Registrar(CursosViewModel mod)
        {
            using (HttpClient client = new HttpClient())
            {

                StringContent content = new StringContent(JsonConvert.SerializeObject(mod), Encoding.UTF8, "application/json");
                string endpoint = _apiUri + enumActions.Register;

                using (var response = await client.PostAsync(endpoint, content))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = JsonConvert.SerializeObject(mod);
                        return RedirectToAction(nameof(ListaCursos), result);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Houve um erro ao fazer o registro");
                    }

                }
            }

            return View();
        }

        public IActionResult Registrar()
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
