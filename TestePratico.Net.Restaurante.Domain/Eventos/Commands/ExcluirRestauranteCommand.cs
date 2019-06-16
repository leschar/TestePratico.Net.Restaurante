using System;
using System.Collections.Generic;
using System.Text;

namespace TestePratico.Net.Restaurante.Domain.Eventos.Commands
{
    public class ExcluirRestauranteCommand:BaseRestauranteCommand
    {
        public ExcluirRestauranteCommand(Guid id)
        {
            Id = id;
            AggregateId = Id;
        }
    }
}
