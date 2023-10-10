using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using Projeto_Final.Model;

namespace Projeto_Final.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().ToTable("tb_produtos");
            modelBuilder.Entity<Categoria>().ToTable("tb_categorias");

                modelBuilder.Entity<Produto>()
                    .HasOne(p => p.Categoria)
                    .WithMany(t => t.Produtos)
                    .HasForeignKey("CategoriaId")
                    .OnDelete(DeleteBehavior.Cascade);

        }

        public DbSet<Produto> Produtos { get; set; } = null!;
        public DbSet<Categoria> Categorias { get; set; } = null!;
    }
}
    

