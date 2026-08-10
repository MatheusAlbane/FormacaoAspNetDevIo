using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PrimeiraApp.Models;

namespace PrimeiraApp.Data
{
    // https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=visual-studio
    public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<Aluno> Alunos { get; set; }        

    }
}
