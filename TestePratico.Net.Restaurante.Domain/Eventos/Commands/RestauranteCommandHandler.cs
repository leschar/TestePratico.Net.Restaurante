using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TestePratico.Net.Restaurante.Core.Notifications;
using TestePratico.Net.Restaurante.Domain.Eventos.Events;
using TestePratico.Net.Restaurante.Domain.Eventos.Repository;
using TestePratico.Net.Restaurante.Domain.Handlers;
using TestePratico.Net.Restaurante.Domain.Interfaces;

namespace TestePratico.Net.Restaurante.Domain.Eventos.Commands
{
    public class RestauranteCommandHandler : CommandHandler, IRequestHandler<RegistrarRestauranteCommand>, IRequestHandler<AtualizarRestauranteCommand>,
        IRequestHandler<ExcluirRestauranteCommand>
    {
        private readonly IMediatorHandler _mediator;
        private readonly IRestauranteRepository _restauranteoRepository;

        public RestauranteCommandHandler(IRestauranteRepository restauranteRepository,
                                        IUnitOfWork uow,
                                        INotificationHandler<DomainNotification> notifications,
                                        IMediatorHandler mediator) : base(uow, mediator, notifications)
        {
            _mediator = mediator;
            _restauranteoRepository = restauranteRepository;
        }

        public Task Handle(RegistrarRestauranteCommand message, CancellationToken cancellationToken)
        {
            var restaurante = Model.Restaurante.RestauranteFactory.RestauranteCompleto(message.Id, message.Nome);

            if (!RestauranteValido(restaurante)) return Task.CompletedTask;
            restaurante.SetDataCadastro();
            //Validação de negócio
            _restauranteoRepository.Adicionar(restaurante);
            if (Commit())
            {
                _mediator.PublicarEvento(new RestauranteRegistradoEvent(restaurante.Id, restaurante.Nome,restaurante.DataCadastro, restaurante.DataAtualizacao));
            }

            return Task.CompletedTask;
        }

        public Task Handle(AtualizarRestauranteCommand message, CancellationToken cancellationToken)
        {
            if (!RestauranteExistente(message.Id, message.MessageType)) return Task.CompletedTask;

            var restaurante = Model.Restaurante.RestauranteFactory.RestauranteCompleto(message.Id, message.Nome);

            
            if (!RestauranteValido(restaurante)) return Task.CompletedTask;

            _restauranteoRepository.Atualizar(restaurante);

            if (Commit())
            {
                _mediator.PublicarEvento(new RestauranteAtualizadoEvent(restaurante.Id, restaurante.Nome,restaurante.DataAtualizacao ));
            }

            return Task.CompletedTask;
        }

        public Task Handle(ExcluirRestauranteCommand message, CancellationToken cancellationToken)
        {
            if (!RestauranteExistente(message.Id, message.MessageType)) return Task.CompletedTask;
            var restauranteAtual = _restauranteoRepository.ObterPorId(message.Id);

            restauranteAtual.ExcluirRestaurante();
            _restauranteoRepository.Atualizar(restauranteAtual);

            if (Commit())
            {
                _mediator.PublicarEvento(new RestauranteExcluidoEvent(message.Id));
            }

            return Task.CompletedTask;
        }

        private bool RestauranteExistente(Guid id, string messageType)
        {
            var evento = _restauranteoRepository.ObterPorId(id);

            if (evento != null) return true;

            _mediator.PublicarEvento(new DomainNotification(messageType, "Restaurante não encontrado."));
            return false;
        }
        private bool RestauranteValido(Model.Restaurante restaurante)
        {
            if (restaurante.EhValido()) return true;

            NotificarValidacoesErro(restaurante.ValidationResult);
            return false;
        }
    }
}
