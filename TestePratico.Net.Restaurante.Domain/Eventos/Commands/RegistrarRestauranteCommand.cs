using System;

namespace TestePratico.Net.Restaurante.Domain.Eventos.Commands
{
    public class RegistrarRestauranteCommand : BaseRestauranteCommand
    {
        public RegistrarRestauranteCommand(string nome)
        {
            Nome = Nome;
            DataCadastro = DateTime.Now;
        }
    }
}
