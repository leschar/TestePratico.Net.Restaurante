using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace TestePratico.Net.Restaurante.Api.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1",new Info
                {
                    Version = "v1",
                    Title = "Teste Pratico .Net Restaurante",
                    Description = "API controle restaurante / cardápio",
                    TermsOfService = "Nenhum",
                    Contact = new Contact { Name = "Charles Fernandes", Email = "email@email.com", Url = "http://arteefotomontagens.com" },
                    License = new License { Name = "MIT", Url = "http://arteefotomontagens.com" }
                });
            });
        }
    }
}
