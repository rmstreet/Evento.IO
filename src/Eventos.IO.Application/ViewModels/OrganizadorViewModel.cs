
namespace Eventos.IO.Application.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class OrganizadorViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Nome é requerido")]
        public string Nome { get; set; }
                
        [Required(ErrorMessage = "O CPF é requerido")]
        [StringLength(11)]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O E-mail é requerido")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido")]
        public string Email { get; set; }
    }
}
