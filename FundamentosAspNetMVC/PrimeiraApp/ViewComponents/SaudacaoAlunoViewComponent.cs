using Microsoft.AspNetCore.Mvc;
using PrimeiraApp.Models;

namespace PrimeiraApp.ViewComponents
{
    public class SaudacaoAlunoViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int nota)
        {
            // Poderia ter pego direto da DB
            var aluno = new Aluno()
            {
                Id = 1,
                Nome = "Matheus Albane",
                DataNascimento = new DateTime(2000, 5, 15),
                Email = "matheusalbane@gmail.com",
                Avaliacao = nota,
                Ativo = true
            };

            return View(aluno);            
        }
    }
}
