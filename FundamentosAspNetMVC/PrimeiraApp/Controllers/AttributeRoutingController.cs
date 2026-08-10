using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PrimeiraApp.Controllers
{
    // Attribute routing
    //[Route("/", Order = 0)] // Define a rota raiz para o controlador
    [Route("minha-conta")]
    public class AttributeRoutingController : Controller
    {
        // GET: Testes
        public ActionResult Index()
        {
            return View();
        }

        // GET: Testes/Details/5
        [HttpGet("detalhes/{id:int}/{id2?}")]
        public ActionResult Details(int id, int id2 = 0)
        {
            return View();
        }

        // GET: Testes/Create
        [HttpGet("novo")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Testes/Create
        [HttpPost("novo")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Testes/Edit/5
        [HttpGet("editar/{id:int}")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Testes/Edit/5
        [HttpPost("editar/{id:int}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,[Bind("FieldsDoFormQueQueroReceber")] IFormCollection collection)
        {                               
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Testes/Delete/5
        [HttpGet("excluir/{id:int}")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Testes/Delete/5
        [HttpPost("excluir/{id:int}")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
