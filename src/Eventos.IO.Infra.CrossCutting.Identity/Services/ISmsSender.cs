
namespace Eventos.IO.Infra.CrossCutting.Identity.Services
{
    using System.Threading.Tasks;

    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
