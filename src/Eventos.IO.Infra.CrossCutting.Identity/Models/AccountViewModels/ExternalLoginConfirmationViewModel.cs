
namespace Eventos.IO.Infra.CrossCutting.Identity.Models.AccountViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
