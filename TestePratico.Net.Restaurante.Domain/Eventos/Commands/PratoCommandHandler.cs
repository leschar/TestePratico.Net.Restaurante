using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TestePratico.Net.Prato.Domain.Eventos.Repository;
using TestePratico.Net.Restaurante.Core.Notifications;
using TestePratico.Net.Restaurante.Domain.Eventos.Commands;
using TestePratico.Net.Restaurante.Domain.Eventos.Events;
using TestePratico.Net.Restaurante.Domain.Handlers;
using TestePratico.Net.Restaurante.Domain.Interfaces;

namespace TestePratico.Net.Prato.Domain.Eventos.Commands
{
    public class PratoCommandHandler : CommandHandler, IRequestHandler<RegistrarPratoCommand>, IRequestHandler<AtualizarPratoCommand>,
        IRequestHandler<ExcluirPratoCommand>
    {
        private readonly IMediatorHandler _mediator;
        private readonly IPratoRepository _pratoRepository;

        public PratoCommandHandler(IPratoRepository pratoRepository,
                                        IUnitOfWork uow,
                                        INotificationHandler<DomainNotification> notifications,
                                        IMediatorHandler mediator) : base(uow, mediator, notifications)
        {
            _mediator = mediator;
            _pratoRepository = pratoRepository;
        }

        public Task Handle(RegistrarPratoCommand message, CancellationToken cancellationToken)
        {
            var prato = TestePratico.Net.Restaurante.Domain.Eventos.Model.Prato.PratoFactory.PratoCompleto(message.Id, message.Nome, message.Valor, message.RestauranteId);

            if (!PratoValido(prato)) return Task.CompletedTask;
            prato.SetDataCadastro();
            //Validação de negócio
            _pratoRepository.Adicionar(prato);
            if (Commit())
            {
                _mediator.PublicarEvento(new PratoRegistradoEvent(prato.Id, prato.Nome, prato.DataCadastro, prato.DataAtualizacao, prato.Valor, prato.RestauranteId));
            }

            return Task.CompletedTask;
        }

        public Task Handle(AtualizarPratoCommand message, CancellationToken cancellationToken)
        {
            if (!PratoExistente(message.Id, message.MessageType)) return Task.CompletedTask;

            var prato = TestePratico.Net.Restaurante.Domain.Eventos.Model.Prato.PratoFactory.PratoCompleto(message.Id, message.Nome, message.Valor, message.RestauranteId);


            if (!PratoValido(prato)) return Task.CompletedTask;

            _pratoRepository.Atualizar(prato);

            if (Commit())
            {
                _mediator.PublicarEvento(new PratoAtualizadoEvent(prato.Id, prato.Nome, prato.DataAtualizacao, prato.Valor, prato.RestauranteId));
            }

            return Task.CompletedTask;
        }

        public Task Handle(ExcluirPratoCommand message, CancellationToken cancellationToken)
        {
            if (!PratoExistente(message.Id, message.MessageType)) return Task.CompletedTask;
            var pratoAtual = _pratoRepository.ObterPorId(message.Id);

            pratoAtual.ExcluirPrato();
            _pratoRepository.Atualizar(pratoAtual);

            if (Commit())
            {
                _mediator.PublicarEvento(new PratoExcluidoEvent(message.Id));
            }

            return Task.CompletedTask;
        }

        private bool PratoExistente(Guid id, string messageType)
        {
            var evento = _pratoRepository.ObterPorId(id);

            if (evento != null) return true;

            _mediator.PublicarEvento(new DomainNotification(messageType, "Prato não encontrado."));
            return false;
        }
        private bool PratoValido(Restaurante.Domain.Eventos.Model.Prato prato)
        {
            if (prato.EhValido()) return true;

            NotificarValidacoesErro(prato.ValidationResult);
            return false;
        }

    }
}
