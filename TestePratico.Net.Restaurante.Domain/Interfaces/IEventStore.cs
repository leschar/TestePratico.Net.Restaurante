using TestePratico.Net.Restaurante.Core.Events;

namespace TestePratico.Net.Restaurante.Domain.Interfaces
{
    public interface IEventStore
    {
        void SalvarEvento<T>(T evento) where T : Event;
    }
}
