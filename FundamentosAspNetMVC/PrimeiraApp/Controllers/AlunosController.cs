using Microsoft.AspNetCore.Mvc;
using PrimeiraApp.Data;
using PrimeiraApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace PrimeiraApp.Controllers
{
    public class AlunosController : Controller
    {
        private readonly AppDbContext _context;

        public AlunosController(AppDbContext DbContext)
        {
            _context = DbContext;
        }
        public async Task<IActionResult> Index()
        {
            var alunos = await _context.Alunos.ToListAsync();

            return View(alunos);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,DataNascimento,Email,EmailConfirmacao,Avaliacao,Ativo")] Aluno aluno)
        {
            // Validação no backend para garantir que dados são consistentes, mesmo que o usuário tente burlar a validação do frontend
            if (ModelState.IsValid)
            {
                _context.Alunos.Add(aluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(aluno); // No html, acrescentar TAG para recuperar erro de validação do backend, caso haja (logo após <form> <div asp-validation-summary="ModelOnly" class="text-danger"></div>)

        }

        public async Task<IActionResult> Details(int id)
        {

            var aluno = await _context.Alunos.FirstOrDefaultAsync(a => a.Id == id);

            return View(aluno);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var aluno = await _context.Alunos.FirstOrDefaultAsync(a => a.Id == id);

            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DataNascimento,Email,EmailConfirmacao,Avaliacao,Ativo")] Aluno aluno)
        {
            if (id != aluno.Id)
            {
                return NotFound();
            }
            
            ModelState.Remove("EmailConfirmacao"); 
            if (ModelState.IsValid)
            {
                _context.Alunos.Update(aluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(aluno);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var aluno = await _context.Alunos.FirstOrDefaultAsync(a => a.Id == id);

            if (aluno != null)
            {
                _context.Alunos.Remove(aluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            TempData["Error"] = $"O aluno de código {id} não foi encontrado para remoção.";
            return RedirectToAction(nameof(Index));
        }
    }
}
