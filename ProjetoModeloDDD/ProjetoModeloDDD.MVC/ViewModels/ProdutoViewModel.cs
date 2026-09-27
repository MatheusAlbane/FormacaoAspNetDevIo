
using ProjetoModeloDDD.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo nome")]
        [MinLength(2, ErrorMessage = "O campo nome deve ter pelo menos {0} caracteres")]
        [MaxLength(150, ErrorMessage = "O campo nome deve ter no máximo {0} caracteres")]
        public string Nome { get; set; }

        [DataType(DataType.Currency)]        
        [Range(typeof(decimal), "0,01", "999999,99", ErrorMessage = "O campo Valor deve estar entre {1} e {2}")]
        [Required(ErrorMessage = "Preencha o campo Valor")]
        public decimal Valor { get; set; }

        [DisplayName("Disponível?")]
        public bool Disponivel { get; set; }

        [ForeignKey("ClienteViewModel")]
        public int ClienteId { get; set; } // Propriedade de navegação para a chave estrangeira do Cliente
        public virtual ClienteViewModel ClienteViewModel { get; set; }        
    }
}