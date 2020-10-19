using Microsoft.EntityFrameworkCore;
using CatalogoProdutosApi.Models;

namespace CatalogoProdutosApi.Data
{
    public class StoreDataContext : DbContext
    {   
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=catalogprod;User ID=sa;Password=******");
        }
    }
}