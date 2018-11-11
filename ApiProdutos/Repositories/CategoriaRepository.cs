using Microsoft.EntityFrameworkCore;
using ApiProdutos.Data;
using ApiProdutos.Models;
using System.Collections.Generic;
using System.Linq;

namespace ApiProdutos.Repositories
{
    public class CategoriaRepository
    {
        #region [IoC]

        private readonly StoreDataContext _context;

        public CategoriaRepository(StoreDataContext context)
        {
            _context = context;
        }

        #endregion [IoC]


        public IEnumerable<Categoria> Get()
        {
            return _context.Categorias.AsNoTracking().ToList();
        }

        public Categoria Get(int id)
        {
            return _context.Categorias.AsNoTracking()
                .Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Produto> GetProdutosPorCategoria(int id)
        {
            return _context.Produtos.AsNoTracking()
                .Where(x => x.CategoriaId == id).ToList();
        }

        public void Save(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
        }

        public void Update(Categoria categoria)
        {
            _context.Entry<Categoria>(categoria).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Categoria categoria)
        {
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
        }
    }
}
