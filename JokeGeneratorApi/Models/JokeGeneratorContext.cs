using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace JokeGeneratorApi.Models
{
    public class JokeGeneratorContext : DbContext
    {
        public JokeGeneratorContext(DbContextOptions<JokeGeneratorContext> options)
            : base(options)
        {
        }

        public DbSet<Joke> Jokes { get; set; } = null!;
    }
}