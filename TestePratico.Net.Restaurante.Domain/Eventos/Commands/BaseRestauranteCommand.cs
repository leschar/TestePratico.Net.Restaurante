using System;
using TestePratico.Net.Restaurante.Core.Commands;

namespace TestePratico.Net.Restaurante.Domain.Eventos.Commands
{
    public abstract class BaseRestauranteCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }
        public DateTime DataCadastro { get; protected set; }
    }
}
