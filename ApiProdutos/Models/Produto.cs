using System;

namespace ApiProdutos.Models
{
    public class Produto
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public int Quantidade { get; set; }

        //public string Imagem { get; set; }

        public DateTime DataEntrada { get; set; }

        //public DateTime DataAtualizacao { get; set; }


        // Category
        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }



    }

}
