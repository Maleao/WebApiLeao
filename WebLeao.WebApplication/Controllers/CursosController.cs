using Microsoft.AspNetCore.Mvc;
using WebLeao.WebApplication.Interfaces;
using WebLeao.WebApplication.Models;

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

        public async Task<IActionResult> Alterar(int Id) 
        {
            if(Id > 0) 
            { 
                var resultado = await _cursosRepository.ObterCursosPorId(Id);
                return View(resultado);
            }
            else
            {
                return NotFound($"{Id} Não Encontrado");
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Alterar(int Id, CursosViewModel mod)
        {
            if (ModelState.IsValid)
            {

                if (Id > 0)
                {
                    await _cursosRepository.Update(Id, mod);
                    TempData["Msg"] = "Curso Alterado com Sucesso";
                    return RedirectToAction(nameof(ListaCursos));
                }
                else
                {
                    return NotFound($"{Id} Não Encontrado");
                }
            }

            return View(mod);
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

        public async Task ExcluirCurso(int Id)
        {
            if (Id > 0)
            {
                await _cursosRepository.Delete(Id);

            }
        }

    }

}
