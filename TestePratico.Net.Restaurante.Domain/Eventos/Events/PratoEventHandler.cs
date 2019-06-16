using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TestePratico.Net.Restaurante.Domain.Eventos.Events;

namespace TestePratico.Net.Prato.Domain.Eventos.Events
{
    public class PratoEventHandler : INotificationHandler<PratoRegistradoEvent>, INotificationHandler<PratoAtualizadoEvent>,
        INotificationHandler<PratoExcluidoEvent>
    {
        public Task Handle(PratoRegistradoEvent notification, CancellationToken cancellationToken)
        {
            //Disparo alguma ação
            return Task.CompletedTask;
        }

        public Task Handle(PratoAtualizadoEvent notification, CancellationToken cancellationToken)
        {
            //Disparo alguma ação
            return Task.CompletedTask;
        }

        public Task Handle(PratoExcluidoEvent notification, CancellationToken cancellationToken)
        {
            //Disparo alguma ação
            return Task.CompletedTask;
        }
    }
}
