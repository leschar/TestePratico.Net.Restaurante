using System;
using System.Collections.Generic;
using System.Text;

namespace TestePratico.Net.Restaurante.Domain.Eventos.Commands
{
    public class RegistrarPratoCommand : BaseRestauranteCommand
    {
        public decimal Valor { get; set; }
        public Guid RestauranteId { get; set; }
        public RegistrarPratoCommand(string nome, decimal valor, Guid restauranteId)
        {
            Nome = nome;
            Valor = valor;
            RestauranteId = restauranteId;
            DataCadastro = DateTime.Now;
        }
    }
}
