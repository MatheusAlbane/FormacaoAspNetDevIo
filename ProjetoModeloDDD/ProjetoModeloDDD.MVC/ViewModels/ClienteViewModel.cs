using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Preencha o campo nome")]
        [MinLength(2, ErrorMessage = "O campo nome deve ter pelo menos {0} caracteres")]
        [MaxLength(150, ErrorMessage = "O campo nome deve ter no máximo {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo sobrenome")]
        [MinLength(2, ErrorMessage = "O campo sobrenome deve ter pelo menos {0} caracteres")]
        [MaxLength(150, ErrorMessage = "O campo sobrenome deve ter no máximo {0} caracteres")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Preencha o campo email")]        
        [MaxLength(100, ErrorMessage = "O campo email deve ter no máximo {0} caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um email válido")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha o campo ativo")]
        public bool Ativo{ get; set; }

        public virtual IEnumerable<ProdutoViewModel> Produtos { get; set; }
        
    }
}