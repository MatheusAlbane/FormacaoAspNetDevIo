using Microsoft.AspNetCore.Mvc;
using PrimeiraApp.Models;

namespace PrimeiraApp.Controllers
{
    public class ModelsController : Controller
    {
        public IActionResult Index()
        {
            var aluno = new Aluno
            {
                Id = 1,
                Nome = "João da Silva",
                DataNascimento = new DateTime(2000, 1, 1),
                Email = "Matheusalbane@gmail.com",
                Avaliacao = 4
            };

            //var aluno = new Aluno();
            if (TryValidateModel(aluno))
            {
                return View(aluno);
            } 

            var ms = ModelState;

            var erros = ModelState.Select(x => x.Value.Errors)
                                   .Where(y => y.Count > 0)                                   
                                   .ToList();

            erros.ForEach(r => Console.WriteLine(r.First().ErrorMessage));

            return View(aluno);
        }
    }
}
