using System;

namespace TestePratico.Net.Restaurante.Domain.Eventos.Commands
{
    public class AtualizarRestauranteCommand : BaseRestauranteCommand
    {
        public DateTime DataAtualizacao { get; protected set; }

        public AtualizarRestauranteCommand(Guid id, string nome)
        {
            Id = id;
            Nome = Nome;
            DataAtualizacao = DateTime.Now;
        }
    }
}
