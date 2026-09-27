using ProjetoModeloDDD.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            HasKey(c => c.ProdutoId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(250);

            Property(c => c.Valor)
                .IsRequired();

            Property(c => c.Disponivel)
                .IsRequired();

            Property(c => c.Ativo)
                .IsRequired();

            // Associação entre Produto e Cliente (um para muitos)
            HasRequired(c => c.Cliente)
                .WithMany()
                .HasForeignKey(c => c.ClienteId); 
        }
    }
}
