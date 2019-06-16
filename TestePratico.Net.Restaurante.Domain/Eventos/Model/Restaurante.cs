using FluentValidation;
using System;
using TestePratico.Net.Restaurante.Core.Models;

namespace TestePratico.Net.Restaurante.Domain.Eventos.Model
{
    public class Restaurante : Entity<Restaurante>
    {
        public string Nome { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime DataAtualizacao { get; private set; }
        public bool Excluido { get; private set; }
        
        public Restaurante() { }
        public Restaurante(string nome)
        {
            Nome = nome;
        }

        public void SetDataCadastro() { DataCadastro = DateTime.Now; }
        public void ExcluirRestaurante()
        {
            Excluido = true;
        }
        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        private void Validar()
        {
            ValidarNome();
            ValidationResult = Validate(this);
        }
        private void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome do restaurante precisa ser fornecido")
                .Length(2, 150).WithMessage("O nome do restaurante precisa ter entre 2 e 150 caracteres");
        }

        public static class RestauranteFactory
        {
            public static Restaurante RestauranteCompleto(Guid id, string nome)
            {
                var restaurante = new Restaurante()
                {
                    Id = id,
                    Nome = nome,
                    DataAtualizacao = DateTime.Now
                };

                return restaurante;
            }
        }
    }
}
