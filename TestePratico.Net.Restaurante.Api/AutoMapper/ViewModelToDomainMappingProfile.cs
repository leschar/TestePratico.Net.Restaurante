using AutoMapper;
using TestePratico.Net.Restaurante.Api.ViewModels;
using TestePratico.Net.Restaurante.Domain.Eventos.Commands;

namespace TestePratico.Net.Restaurante.Api.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<RestauranteViewModel, RegistrarRestauranteCommand>()
                .ConstructUsing(c => new RegistrarRestauranteCommand(c.Nome));

            CreateMap<RestauranteViewModel, AtualizarRestauranteCommand>()
               .ConstructUsing(c => new AtualizarRestauranteCommand(c.Id, c.Nome));

            CreateMap<RestauranteViewModel, ExcluirRestauranteCommand>()
                .ConstructUsing(c => new ExcluirRestauranteCommand(c.Id));

            CreateMap<PratoViewModel, RegistrarPratoCommand>()
                .ConstructUsing(c => new RegistrarPratoCommand(c.Nome, c.Valor,c.RestauranteId));

            CreateMap<PratoViewModel, AtualizarPratoCommand>()
               .ConstructUsing(c => new AtualizarPratoCommand(c.Id, c.Nome, c.Valor, c.RestauranteId));

            CreateMap<PratoViewModel, ExcluirPratoCommand>()
                .ConstructUsing(c => new ExcluirPratoCommand(c.Id));
        }
    }
}
