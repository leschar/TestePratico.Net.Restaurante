using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TestePratico.Net.Restaurante.Api.ViewModels;
using TestePratico.Net.Restaurante.Core.Notifications;
using TestePratico.Net.Restaurante.Domain.Eventos.Commands;
using TestePratico.Net.Restaurante.Domain.Eventos.Repository;
using TestePratico.Net.Restaurante.Domain.Interfaces;

namespace TestePratico.Net.Restaurante.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class RestauranteController : BaseController
    {
        private readonly IRestauranteRepository _restauranteRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public RestauranteController(INotificationHandler<DomainNotification> notifications,
                                 IRestauranteRepository restauranteRepository,
                                 IMapper mapper,
                                 IMediatorHandler mediator) : base(notifications, mediator)
        {
            _restauranteRepository = restauranteRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<RestauranteViewModel> Get()
        {
            return _mapper.Map<IEnumerable<RestauranteViewModel>>(_restauranteRepository.ObterTodos());
        }

        [HttpGet("{nome}")]
        [AllowAnonymous]
        public RestauranteViewModel Get(string nome)
        {
            return _mapper.Map<RestauranteViewModel>(_restauranteRepository.ObterPorNome(nome));
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody]RestauranteViewModel restauranteViewModel)
        {
            if (!ModelStateValida())
            {
                return Response();
            }

            var restauranteCommand = _mapper.Map<RegistrarRestauranteCommand>(restauranteViewModel);

            _mediator.EnviarComando(restauranteCommand);
            return Response(restauranteCommand);
        }

        [HttpPut]
        [AllowAnonymous]
        public IActionResult Put([FromBody]RestauranteViewModel restauranteViewModel)
        {
            if (!ModelStateValida())
            {
                return Response();
            }

            var restauranteCommand = _mapper.Map<AtualizarRestauranteCommand>(restauranteViewModel);

            _mediator.EnviarComando(restauranteCommand);
            return Response(restauranteCommand);
        }

        [HttpDelete]
        [AllowAnonymous]
        public IActionResult Delete(Guid id)
        {
            var restauranteViewModel = new RestauranteViewModel { Id = id };
            var eventoCommand = _mapper.Map<ExcluirRestauranteCommand>(restauranteViewModel);

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