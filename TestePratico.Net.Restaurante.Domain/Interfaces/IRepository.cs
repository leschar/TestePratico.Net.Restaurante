using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TestePratico.Net.Restaurante.Core.Models;

namespace TestePratico.Net.Restaurante.Domain.Interfaces
{
    public interface IRepository<T> : IDisposable where T : Entity<T>
    {
        void Adicionar(T obj);
        T ObterPorId(Guid id);
        IEnumerable<T> ObterTodos();
        void Atualizar(T obj);
        void Remover(Guid id);
        IEnumerable<T> Buscar(Expression<Func<T, bool>> predicate);
        int SaveChanges();
    }
}
