using System;

namespace TestePratico.Net.Restaurante.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
