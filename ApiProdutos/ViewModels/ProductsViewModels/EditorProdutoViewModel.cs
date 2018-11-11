using Flunt.Notifications;
using Flunt.Validations;

namespace ApiProdutos.ViewModels.ProductsViewModels
{
    public class EditorProdutoViewModel : Notifiable, IValidatable
    {
        #region [ PROPRIEDADES ]

        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public int Quantidade { get; set; }

        //public string Imagem { get; set; }

        public int CategoriaId { get; set; }

        #endregion [ PROPRIEDADES ]

        #region [ VALIDAÇÕES ]

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .HasMaxLen(Titulo, 120, "Titulo", "O título deve conter até 120 caracteres")
                    .HasMinLen(Titulo, 3, "Titulo", "O título deve conter pelo menos 3 caracteres")

                    .HasMaxLen(Descricao, 120, "Descricao", "A descrição deve conter até 120 caracteres")
                    .HasMinLen(Descricao, 3, "Descricao", "A descrição conter pelo menos 3 caracteres")

                    .IsGreaterThan(Valor, 0, "Valor", "O valor do produto deve ser maior que zero")
                    
                    .IsGreaterThan(Quantidade, 0, "Quantidade", "A quantidade deve ser maior que zero")

                );

        }
        #endregion [ VALIDAÇÕES ]

    }
}
