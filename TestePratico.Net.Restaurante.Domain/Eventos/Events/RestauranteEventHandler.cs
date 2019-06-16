using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace TestePratico.Net.Restaurante.Domain.Eventos.Events
{
    public class RestauranteEventHandler : INotificationHandler<RestauranteRegistradoEvent>, INotificationHandler<RestauranteAtualizadoEvent>,
        INotificationHandler<RestauranteExcluidoEvent>
    {
        public Task Handle(RestauranteRegistradoEvent notification, CancellationToken cancellationToken)
        {
            //Disparo alguma ação
            return Task.CompletedTask;
        }

        public Task Handle(RestauranteAtualizadoEvent notification, CancellationToken cancellationToken)
        {
            //Disparo alguma ação
            return Task.CompletedTask;
        }

        public Task Handle(RestauranteExcluidoEvent notification, CancellationToken cancellationToken)
        {
            //Disparo alguma ação
            return Task.CompletedTask;
        }
    }
}
