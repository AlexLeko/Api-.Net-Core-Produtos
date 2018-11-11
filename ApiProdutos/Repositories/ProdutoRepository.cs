using Microsoft.EntityFrameworkCore;
using ApiProdutos.Data;
using ApiProdutos.Models;
using ApiProdutos.ViewModels.ProductsViewModels;
using System.Collections.Generic;
using System.Linq;

namespace ApiProdutos.Repositories
{
    public class ProdutoRepository
    {
        #region [IoC]
        private readonly StoreDataContext _context;

        public ProdutoRepository(StoreDataContext context)
        {
            _context = context;
        }
        #endregion [IoC]


        #region [GET]
        public IEnumerable<ListaProdutosViewModel> Get()
        {
            return _context.Produtos
               .Include(x => x.Categoria)
               .Select(x => new ListaProdutosViewModel
               {
                   Id = x.Id,
                   Titulo = x.Titulo,
                   Valor = x.Valor,
                   Categoria = x.Categoria.Titulo,
                   CategoriaId = x.CategoriaId
               })
               .AsNoTracking()
               .ToList();
        }

        public DetalheProdutosViewModel Get(int id)
        {
            var produto = _context.Produtos
                .Include(x => x.Categoria)
                .Select(x => new DetalheProdutosViewModel
                {
                    Id = x.Id,
                    Titulo = x.Titulo,
                    Descricao = x.Descricao,
                    Valor = x.Valor,
                    Categoria = x.Categoria.Titulo,
                    CategoriaId = x.CategoriaId
                })
                .AsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            return produto != null ? produto : new DetalheProdutosViewModel();
        }

        #endregion [GET]


        public void Save(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public void Update(Produto produto)
        {
            _context.Entry<Produto>(produto).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Produto Find(int id)
        {
            return _context.Produtos.Find(id);
        }

        public void Delete(int id)
        {
            var produto = _context.Produtos.Find(id);

            _context.Produtos.Remove(produto);
            _context.SaveChanges();
        }

    }
}
