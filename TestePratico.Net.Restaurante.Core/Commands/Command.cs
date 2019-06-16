using MediatR;
using System;
using TestePratico.Net.Restaurante.Core.Events;

namespace TestePratico.Net.Restaurante.Core.Commands
{
    public class Command : Message, IRequest
    {
        public DateTime Timestamp { get; private set; }

        public Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
