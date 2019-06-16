using System.Threading.Tasks;
using TestePratico.Net.Restaurante.Core.Commands;
using TestePratico.Net.Restaurante.Core.Events;

namespace TestePratico.Net.Restaurante.Domain.Interfaces
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task EnviarComando<T>(T comando) where T : Command;
    }
}
