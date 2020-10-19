using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CatalogoProdutosApi.Data;
using CatalogoProdutosApi.Models;

namespace CatalogoProdutosApi.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly StoreDataContext _context;

        public CategoriaController(StoreDataContext context)
        {
            _context = context;
        }

        [Route("v1/categorias")]
        [HttpGet]
        public IEnumerable<Categoria> Get()
        {
            return _context.Categorias.AsNoTracking().ToList();
        }

        [Route("v1/categorias/{id}")]
        [HttpGet]
        public Categoria Get(int id)
        {
            return _context.Categorias.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }

        [Route("v1/categorias/{id}/produtos")]
        [HttpGet]
        public IEnumerable<Produto> GetProdutos(int id)
        {
            return _context.Produtos.AsNoTracking().Where(x => x.IdCategoria == id).ToList();
        }

        [Route("v1/categorias")]
        [HttpPost]
        public Categoria Post([FromBody]Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return categoria;
        }

        [Route("v1/categorias")]
        [HttpPut]
        public Categoria Put([FromBody]Categoria categoria)
        {
            _context.Entry<Categoria>(categoria).State = EntityState.Modified;
            _context.SaveChanges();
            return categoria;
        }

        [Route("v1/categorias")]
        [HttpDelete]
        public Categoria Delete([FromBody]Categoria categoria)
        {
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
            return categoria;
        }
    }
}