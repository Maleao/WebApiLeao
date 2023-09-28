using Microsoft.AspNetCore.Mvc;
using WebLeao.WebApplication.Models;
using WebLeao.WebApplication.EnumVerbs;
using Newtonsoft.Json;
using WebLeao.WebApplication.Interfaces;

namespace WebLeao.WebApplication.Controllers
{
    public class CursosController : Controller
    {
        readonly string _apiUri;
        private readonly IConfiguration _config;
        private readonly ICursosRepository _cursosRepository;

        public CursosController(IConfiguration config, ICursosRepository cursosRepository)
        {
            _config = config;
            _cursosRepository = cursosRepository;
            _apiUri = _config.GetValue<string>("Uri");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(CursosViewModel mod)
        {
            //Sem o Rift

            //using (HttpClient client = new HttpClient())
            //{

            //    StringContent content = new StringContent(JsonConvert.SerializeObject(mod), Encoding.UTF8, "application/json");
            //    string endpoint = _apiUri + enumActions.Register;

            //    using (var response = await client.PostAsync(endpoint, content))
            //    {
            //        if (response.StatusCode == HttpStatusCode.OK)
            //        {
            //            var result = JsonConvert.SerializeObject(mod);
            //            return RedirectToAction(nameof(ListaCursos));
            //        }
            //        else
            //        {
            //            ModelState.AddModelError("", "Houve um erro ao fazer o registro");
            //        }

            //    }
            //}

            await _cursosRepository.Registrar(mod);
            return RedirectToAction(nameof(ListaCursos));

           // return View();
        }

        public IActionResult Registrar()
        {
            return View();
        }

        public async Task<IActionResult> ListaCursos()
        {
            //Sem rift
            //return View(await GetCursos());
            return View(await _cursosRepository.ObterCursos());
        }

        //public async Task<IEnumerable<CursosViewModel>?> GetCursos()
        //{
        //    using (HttpClient httpClient = new HttpClient())
        //    {
        //        var cursos = new CursosViewModel();

        //        HttpResponseMessage response = await httpClient.GetAsync(_apiUri + enumActions.ObterTodosCursos);
        //        if(response.IsSuccessStatusCode)
        //        {
        //            var dados = await response.Content.ReadAsStringAsync();
        //            return JsonConvert.DeserializeObject<IEnumerable<CursosViewModel>>(dados);

        //        }

        //        return new List<CursosViewModel>();
        //    }
        //}
    }
}
