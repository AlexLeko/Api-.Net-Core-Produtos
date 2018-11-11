namespace ApiProdutos.ViewModels.ProductsViewModels
{
    public class ListaProdutosViewModel
    {
        #region [ PROPRIEDADES ]

        public int Id { get; set; }

        public string Titulo { get; set; }

        public decimal Valor { get; set; }

        public int CategoriaId { get; set; }

        public string Categoria { get; set; }

        #endregion [ PROPRIEDADES ]

    }
}
