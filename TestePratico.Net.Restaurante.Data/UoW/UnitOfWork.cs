using TestePratico.Net.Restaurante.Data.Context;
using TestePratico.Net.Restaurante.Domain.Interfaces;

namespace TestePratico.Net.Restaurante.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RestauranteContext _context;

        public UnitOfWork(RestauranteContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
