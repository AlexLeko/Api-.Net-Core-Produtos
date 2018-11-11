using Flunt.Notifications;
using Flunt.Validations;

namespace ApiProdutos.ViewModels.ProductsViewModels
{
    public class DetalheProdutosViewModel : Notifiable, IValidatable
    {
        #region [ PROPRIEDADES ]

        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public int CategoriaId { get; set; }

        public string Categoria { get; set; }

        #endregion [ PROPRIEDADES ]

        #region [ VALIDAÇÕES ]

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .IsGreaterThan(Id, 0, "Id", "Nenhum produto com este id foi encontrado.")
                );
        }

        #endregion [ VALIDAÇÕES ]



    }
}
