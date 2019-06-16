using FluentValidation;
using System;
using TestePratico.Net.Restaurante.Core.Models;

namespace TestePratico.Net.Restaurante.Domain.Eventos.Model
{
    public class Prato : Entity<Prato>
    {
        public string Nome { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime DataAtualizacao { get; private set; }
        public bool Excluido { get; private set; }
        public Guid RestauranteId { get; private set; }

        public Prato() { }
        public Prato(string nome, decimal valor, Guid restauranteId)
        {
            Nome = nome;
            Valor = valor;
            RestauranteId = restauranteId;
        }

        public void SetDataCadastro() { DataCadastro = DateTime.Now; }
        public void ExcluirPrato()
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
            ValidarValor();
            ValidationResult = Validate(this);
        }
        private void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome do prato precisa ser fornecido")
                .Length(2, 150).WithMessage("O nome do prato precisa ter entre 2 e 150 caracteres");
        }
        private void ValidarValor()
        {
            RuleFor(c => c.Valor)
                .ExclusiveBetween(1, 50000)
                .WithMessage("O valor deve estar entre 1.00 e 50.000");
        }

        public static class PratoFactory
        {
            public static Prato PratoCompleto(Guid id, string nome, decimal valor, Guid restauranteId)
            {
                var prato = new Prato()
                {
                    Id = id,
                    Nome = nome,
                    DataAtualizacao = DateTime.Now,
                    Valor = valor,
                    RestauranteId = restauranteId
                };

                return prato;
            }
        }
    }
}
