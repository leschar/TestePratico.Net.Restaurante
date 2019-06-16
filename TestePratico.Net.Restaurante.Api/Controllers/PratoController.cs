using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TestePratico.Net.Prato.Domain.Eventos.Repository;
using TestePratico.Net.Restaurante.Api.Controllers;
using TestePratico.Net.Restaurante.Api.ViewModels;
using TestePratico.Net.Restaurante.Core.Notifications;
using TestePratico.Net.Restaurante.Domain.Eventos.Commands;
using TestePratico.Net.Restaurante.Domain.Interfaces;

namespace TestePratico.Net.Prato.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PratoController : BaseController
    {
        private readonly IPratoRepository _pratoRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public PratoController(INotificationHandler<DomainNotification> notifications,
                                 IPratoRepository pratoRepository,
                                 IMapper mapper,
                                 IMediatorHandler mediator) : base(notifications, mediator)
        {
            _pratoRepository = pratoRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<PratoViewModel> Get()
        {
            return _mapper.Map<IEnumerable<PratoViewModel>>(_pratoRepository.ObterTodos());
        }

        [HttpGet("{nome}")]
        [AllowAnonymous]
        public PratoViewModel Get(string nome)
        {
            return _mapper.Map<PratoViewModel>(_pratoRepository.ObterPorNome(nome));
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody]PratoViewModel pratoViewModel)
        {
            if (!ModelStateValida())
            {
                return Response();
            }

            var pratoCommand = _mapper.Map<RegistrarPratoCommand>(pratoViewModel);

            _mediator.EnviarComando(pratoCommand);
            return Response(pratoCommand);
        }

        [HttpPut]
        [AllowAnonymous]
        public IActionResult Put([FromBody]PratoViewModel pratoViewModel)
        {
            if (!ModelStateValida())
            {
                return Response();
            }

            var pratoCommand = _mapper.Map<AtualizarPratoCommand>(pratoViewModel);

            _mediator.EnviarComando(pratoCommand);
            return Response(pratoCommand);
        }

        [HttpDelete]
        [AllowAnonymous]
        public IActionResult Delete(Guid id)
        {
            var pratoViewModel = new PratoViewModel { Id = id };
            var eventoCommand = _mapper.Map<ExcluirPratoCommand>(pratoViewModel);

            _mediator.EnviarComando(eventoCommand);
            return Response(eventoCommand);
        }
        private bool ModelStateValida()
        {
            if (ModelState.IsValid) return true;

            NotificarErroModelInvalida();
            return false;
        }
    }
}