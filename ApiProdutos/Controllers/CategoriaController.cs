using Microsoft.AspNetCore.Mvc;
using ApiProdutos.Models;
using ApiProdutos.Repositories;
using System.Collections.Generic;

namespace ApiProdutos.Controllers
{
    //[Produces("application/json")]
    //[Route("api/")]
    public class CategoriaController : ControllerBase
    {
        #region [IoC]
        private readonly CategoriaRepository _repository;

        public CategoriaController(CategoriaRepository repository)
        {
            _repository = repository;
        }
        #endregion [IoC]

        #region [GET]

        [HttpGet]
        [Route("v1/categorias")]
        //[ResponseCache(Duration = 5)]
        public IEnumerable<Categoria> Get()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("v1/categorias/{id}")]
        //[ResponseCache(Duration = 5)]
        public Categoria Get(int id)
        {
            return _repository.Get(id);
        }

        [HttpGet]
        [Route("v1/categorias/{id}/produtos")]
        //[ResponseCache(Duration = 5)]
        public IEnumerable<Produto> GetProdutosPorCategoria(int categoriaID)
        {
            return _repository.GetProdutosPorCategoria(categoriaID);
        }

        #endregion [GET]


        [HttpPost]
        [Route("v1/categorias")]
        public Categoria Post([FromBody]Categoria categoria)
        {
            _repository.Save(categoria);
            return categoria;
        }

        [HttpPut]
        [Route("v1/categorias")]
        public Categoria Put([FromBody] Categoria categoria)
        {
            _repository.Update(categoria);
            return categoria;
        }

        [HttpDelete]
        [Route("v1/categorias")]
        public Categoria Delete([FromBody] Categoria categoria)
        {
            _repository.Delete(categoria);
            return categoria;
        }
    }

}
