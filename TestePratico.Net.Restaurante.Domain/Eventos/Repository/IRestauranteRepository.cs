using TestePratico.Net.Restaurante.Domain.Interfaces;

namespace TestePratico.Net.Restaurante.Domain.Eventos.Repository
{
    public interface IRestauranteRepository : IRepository<Model.Restaurante>
    {
        Eventos.Model.Restaurante ObterPorNome(string nome);
    }
}
