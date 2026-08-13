using Microsoft.EntityFrameworkCore;
using ProjetoDBZ.Models;

namespace ProjetoDBZ.Data
{
    // cria a classe AppDbContext que herda de DbContext, que é a classe base do Entity Framework Core para trabalhar com o banco de dados.
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Cria a tabela no banco de dados com o nome "DBZ" e define a entidade Personagem como o modelo para essa tabela.
        public DbSet<Personagem>DBZ {get; set;}
    }
}