using Microsoft.AspNetCore.Mvc;
using ApiProdutos.Models;
using ApiProdutos.Repositories;
using ApiProdutos.ViewModels;
using ApiProdutos.ViewModels.ProductsViewModels;
using System;
using System.Collections.Generic;

namespace ApiProdutos.Controllers
{
    public class ProdutoController : Controller
    {
        #region [IoC]
        private readonly ProdutoRepository _repository;

        public ProdutoController(ProdutoRepository repository)
        {
            _repository = repository;
        }
        #endregion [IoC]

        [HttpGet]
        [Route("produtos")]
        public IEnumerable<ListaProdutosViewModel> Get()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("produtos/{id}")]
        public ResultViewModel Get(int id)
        {
            var produto = _repository.Get(id);

            produto.Validate();
            if (produto.Notifications.Count > 0)
               return RetornoResult(false, "Nenhum produto foi encotrado.", produto.Notifications);
            else
                return RetornoResult(true, "O produto foi encontrado", produto);
        }

        [HttpPost]
        [Route("produtos")]
        public ResultViewModel Post([FromBody]EditorProdutoViewModel model)
        {
            model.Validate();
            if (model.Invalid)
                return RetornoResult(false, "Não foi possível cadastrar o produto.", model.Notifications);
            
            var product = new Produto();
            product.Titulo = model.Titulo;
            product.CategoriaId = model.CategoriaId;
            product.DataEntrada = DateTime.Now;
            product.Descricao = model.Descricao;
            product.Valor = model.Valor;
            product.Quantidade = model.Quantidade;

            _repository.Save(product);

            return RetornoResult(true, "Produto cadastrado com sucesso.", product);
        }


        [HttpPut]
        [Route("produtos")]
        public ResultViewModel Put([FromBody]EditorProdutoViewModel model)
        {
            model.Validate();
            if (model.Invalid)
                return RetornoResult(false, "Não foi possível alterar o produto.", model.Notifications);

            var product = _repository.Find(model.Id);

            product.Titulo = model.Titulo;
            product.CategoriaId = model.CategoriaId;
            product.Descricao = model.Descricao;
            product.Valor = model.Valor;
            product.Quantidade = model.Quantidade;

            _repository.Update(product);

            return RetornoResult(true, "O Produto foi alterado com sucesso.", product);
        }

        [HttpDelete]
        [Route("produtos/{id}")]
        public ResultViewModel Delete(int id)
        {
            _repository.Delete(id);

            return RetornoResult(true, "Produto excluido com sucesso.", new object());
        }



        #region [ AUXILIARES ]

        private ResultViewModel RetornoResult(bool status, string message, object data)
        {
            var retorno = new ResultViewModel
            {
                Sucess = status,
                Message = message,
                Data = data
            };

            return retorno;
        }

        #endregion [ AUXILIARES ]

    }
}
