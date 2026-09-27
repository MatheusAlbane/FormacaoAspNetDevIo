using System;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Interfaces
{
    // Contrato genérico para repositórios, definindo operações básicas de CRUD (Create, Read, Update, Delete)
    // para entidades do tipo TEntity.
    
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Dispose();
        void Remove(TEntity obj);
    }
}
