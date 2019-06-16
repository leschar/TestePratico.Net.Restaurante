using TestePratico.Net.Restaurante.Domain.Interfaces;

namespace TestePratico.Net.Prato.Domain.Eventos.Repository
{
    public interface IPratoRepository : IRepository<Restaurante.Domain.Eventos.Model.Prato>
    {
        Restaurante.Domain.Eventos.Model.Prato ObterPorNome(string nome);
    }
}
