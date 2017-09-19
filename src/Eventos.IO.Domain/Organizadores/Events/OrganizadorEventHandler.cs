
namespace Eventos.IO.Domain.Organizadores.Events
{
    using Core.Events;

    public class OrganizadorEventHandler :
        IHandler<OrganizadorRegistradoEvent>
    {
        public void Handle(OrganizadorRegistradoEvent message)
        {
            // TODO: Enviar um email?
        }
    }
}
