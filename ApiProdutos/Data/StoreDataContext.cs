using ApiProdutos.Data.Maps;
using ApiProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProdutos.Data
{
    public class StoreDataContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=N001912\\SQLEXPRESS;Database=API_Produtos;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
        }
    }
}
