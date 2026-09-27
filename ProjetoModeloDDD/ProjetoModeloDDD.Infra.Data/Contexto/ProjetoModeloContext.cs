using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace ProjetoModeloDDD.Infra.Data.Contexto
{
    // Instalar pelo PMC -> Install-Package EntityFramework -Version 6.4.4
    public class ProjetoModeloContext : DbContext
    {
        public ProjetoModeloContext() : base("ProjetoModeloDDD") // Nome da connection string no arquivo Web.config
        {

        }

        // Para toda classe, adicionar um DbSet para que o Entity Framework
        // possa mapear a entidade para uma tabela no banco de dados.
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Desabilitar convenções desnecessárias do Entity Framework
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); // Produtos viraria Produto"es"
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); // Desabilitar exclusão em cascata
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>(); // Desabilitar exclusão em cascata

            // Column contendo nome ID no final, será automaticamente considerada PK
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            // Tudo que for criado como string, será convertido para varchar(100) no banco de dados
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            // Adicionar configurações de mapeamento para a entidade Cliente (EntityConfig.ClienteConfiguration)
            modelBuilder.Configurations.Add(new EntityConfig.ClienteConfiguration());
            modelBuilder.Configurations.Add(new EntityConfig.ProdutoConfiguration());
        }

        // Forçar valores default para as propriedades de auditoria (CreatedAt, UpdatedAt, DeletedAt)
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChanges();
        }
    }
}