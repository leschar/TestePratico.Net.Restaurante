using System;
using System.Collections.Generic;
using System.Text;

namespace TestePratico.Net.Restaurante.Domain.Eventos.Commands
{
    public class AtualizarPratoCommand : BaseRestauranteCommand
    {
        public DateTime DataAtualizacao { get; protected set; }
        public decimal Valor { get; protected set; }
        public Guid RestauranteId { get; set; }
        public AtualizarPratoCommand(Guid id, string nome, decimal valor, Guid restauranteId)
        {
            Id = id;
            Nome = Nome;
            DataAtualizacao = DateTime.Now;
            Valor = valor;
            RestauranteId = restauranteId;
        }
    }
}
