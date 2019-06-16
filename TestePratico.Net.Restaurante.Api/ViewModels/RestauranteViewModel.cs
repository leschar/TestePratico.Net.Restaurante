using System;
using System.ComponentModel.DataAnnotations;

namespace TestePratico.Net.Restaurante.Api.ViewModels
{
    public class RestauranteViewModel
    {
        public RestauranteViewModel()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Nome é requerido")]
        [MinLength(2, ErrorMessage = "O tamanho minimo do Nome é {1}")]
        [MaxLength(150, ErrorMessage = "O tamanho máximo do Nome é {1}")]
        [Display(Name = "Nome do Restaurante")]
        public string Nome { get; set; }

    }
}
