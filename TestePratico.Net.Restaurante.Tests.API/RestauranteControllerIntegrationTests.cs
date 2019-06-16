using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestePratico.Net.Restaurante.Api.ViewModels;
using TestePratico.Net.Restaurante.Tests.API.DTO;
using Xunit;

namespace TestePratico.Net.Restaurante.Tests.API
{
    public class RestauranteControllerIntegrationTests
    {
        public RestauranteControllerIntegrationTests()
        {
            Environment.CriarServidor();
        }

        [Fact(DisplayName = "Restaurante registrado com sucesso")]
        [Trait("Category", "Testes de integração API")]
        public async Task RestauranteController_RegistrarNovoRestaurante_RetornarComSucesso()
        {   
            var restaurante = new RestauranteViewModel
            {
                Nome = "Restaurante X"
            };

            // Act
            var response = await Environment.Server
                .CreateRequest("api/restaurante")
                .And(
                    request =>
                        request.Content =
                            new StringContent(JsonConvert.SerializeObject(restaurante), Encoding.UTF8, "application/json"))
                .PostAsync();

            var result = JsonConvert.DeserializeObject<EventoReturnJson>(await response.Content.ReadAsStringAsync());

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.IsType<RestauranteDTO>(result.data);
        }
    }
}
