using Microsoft.EntityFrameworkCore;
using System.Linq;
using TestePratico.Net.Prato.Domain.Eventos.Repository;
using TestePratico.Net.Restaurante.Data.Context;
using TestePratico.Net.Restaurante.Data.Repository;

namespace TestePratico.Net.Prato.Data.Repository
{
    public class PratoRepository : Repository<Restaurante.Domain.Eventos.Model.Prato>, IPratoRepository
    {
        public PratoRepository(RestauranteContext context) : base(context)
        {
        }
        public Restaurante.Domain.Eventos.Model.Prato ObterPorNome(string nome)
        {
            return DbSet.AsNoTracking().FirstOrDefault(t => t.Nome == nome);
        }
    }
}
