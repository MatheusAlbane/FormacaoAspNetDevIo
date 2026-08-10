using Microsoft.AspNetCore.Mvc;
using PrimeiraApp.Data;
using PrimeiraApp.Models;

namespace PrimeiraApp.Controllers
{
    public class TesteEFController : Controller
    {
        public AppDbContext Db { get; set; }
        public TesteEFController(AppDbContext db)
        {
            Db = db;
        }

        public IActionResult Index()
        {
            var aluno = new Aluno()
            {
                Nome = "Albane",
                DataNascimento = new DateTime(2000, 1, 1),
                Email = "albane@gmail.com",
                Avaliacao = 3,
                Ativo = true
            };

            Db.Alunos.Add(aluno);
            Db.SaveChanges();

            var alunosChange = Db.Alunos.Where(a => a.Nome.Contains("Albane")).FirstOrDefault();
            //alunosChange.Nome = "Matheus Albane";
            //Db.Alunos.Update(alunosChange);
            //Db.SaveChanges();

            Db.Alunos.Remove(alunosChange);
            Db.SaveChanges();

            return RedirectToAction("Index", "AttributeRouting");
        }
    }
}
