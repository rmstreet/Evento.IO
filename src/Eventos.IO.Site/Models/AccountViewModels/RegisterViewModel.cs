using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.IO.Site.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "O Nome é requerido")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF é requerido")]
        [StringLength(11)]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O E-mail é requerido")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} deve conter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar a senha")]
        [Compare("Password", ErrorMessage = "A senha e a confirmação de senha não são iguais.")]
        public string ConfirmPassword { get; set; }
    }
}
