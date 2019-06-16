using Microsoft.EntityFrameworkCore;
using System.Linq;
using TestePratico.Net.Restaurante.Data.Context;
using TestePratico.Net.Restaurante.Domain.Eventos.Repository;

namespace TestePratico.Net.Restaurante.Data.Repository
{
    public class RestauranteRepository : Repository<Domain.Eventos.Model.Restaurante>, IRestauranteRepository
    {
        public RestauranteRepository(RestauranteContext context) : base(context)
        {
        }
        public Domain.Eventos.Model.Restaurante ObterPorNome(string nome)
        {
            return DbSet.AsNoTracking().FirstOrDefault(t => t.Nome == nome);
        }
    }
}
