namespace ProjetoModeloDDD.Domain.Entities
{
    public class Produto : Base
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public bool Disponivel { get; set; }
        public int ClienteId { get; set; } // Propriedade de navegação para a chave estrangeira do Cliente
        public virtual Cliente Cliente { get; set; } 
    }
}
