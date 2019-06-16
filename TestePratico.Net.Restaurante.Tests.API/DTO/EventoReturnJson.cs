using System;
using System.Collections.Generic;
using System.Text;

namespace TestePratico.Net.Restaurante.Tests.API.DTO
{
    public class EventoReturnJson
    {
        public bool success { get; set; }
        public RestauranteDTO data { get; set; }
    }

    public class RestauranteDTO
    {
        public string id { get; set; }
        public string nome { get; set; }
        public bool excluido { get; set; }
        public DateTime datacadastro { get; set; }
        public DateTime dataatualizacao { get; set; }
        public DateTime timestamp { get; set; }
        public string messageType { get; set; }
        public string aggregateId { get; set; }
    }
}
