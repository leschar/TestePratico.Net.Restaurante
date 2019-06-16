using AutoMapper;
using TestePratico.Net.Restaurante.Api.ViewModels;

namespace TestePratico.Net.Restaurante.Api.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Domain.Eventos.Model.Restaurante, RestauranteViewModel>();
        }
    }
}
