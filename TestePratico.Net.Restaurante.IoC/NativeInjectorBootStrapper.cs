using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using TestePratico.Net.Restaurante.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using TestePratico.Net.Restaurante.Domain.Eventos.Commands;
using TestePratico.Net.Restaurante.Core.Notifications;
using TestePratico.Net.Restaurante.Domain.Eventos.Events;
using TestePratico.Net.Restaurante.Domain.Eventos.Repository;
using TestePratico.Net.Restaurante.Data.Repository;
using TestePratico.Net.Restaurante.Data.UoW;
using TestePratico.Net.Restaurante.Data.Context;
using TestePratico.Net.Restaurante.Data.Repository.EventSourcing;
using TestePratico.Net.Restaurante.Data.EventSourcing;
using TestePratico.Net.Restaurante.AspNetFilters;
using TestePratico.Net.Prato.Domain.Eventos.Commands;
using TestePratico.Net.Prato.Domain.Eventos.Events;
using TestePratico.Net.Prato.Domain.Eventos.Repository;
using TestePratico.Net.Prato.Data.Repository;

namespace TestePratico.Net.Restaurante.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASPNET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, Domain.Handlers.MediatorHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegistrarRestauranteCommand>, RestauranteCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarRestauranteCommand>, RestauranteCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirRestauranteCommand>, RestauranteCommandHandler>();

            services.AddScoped<IRequestHandler<RegistrarPratoCommand>, PratoCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarPratoCommand>, PratoCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirPratoCommand>, PratoCommandHandler>();

            // Domain - Eventos
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<RestauranteRegistradoEvent>, RestauranteEventHandler>();
            services.AddScoped<INotificationHandler<RestauranteAtualizadoEvent>, RestauranteEventHandler>();
            services.AddScoped<INotificationHandler<RestauranteExcluidoEvent>, RestauranteEventHandler>();

            services.AddScoped<INotificationHandler<PratoRegistradoEvent>, PratoEventHandler>();
            services.AddScoped<INotificationHandler<PratoAtualizadoEvent>, PratoEventHandler>();
            services.AddScoped<INotificationHandler<PratoExcluidoEvent>, PratoEventHandler>();

            // Infra - Data
            services.AddScoped<IRestauranteRepository, RestauranteRepository>();
            services.AddScoped<IPratoRepository, PratoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<RestauranteContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();

            // Infra - Filtros
            services.AddScoped<ILogger<GlobalExceptionHandlingFilter>, Logger<GlobalExceptionHandlingFilter>>();
            services.AddScoped<ILogger<GlobalActionLogger>, Logger<GlobalActionLogger>>();
            services.AddScoped<GlobalExceptionHandlingFilter>();
            services.AddScoped<GlobalActionLogger>();
        }
    }
}
