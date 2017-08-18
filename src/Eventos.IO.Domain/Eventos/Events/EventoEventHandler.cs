
namespace Eventos.IO.Domain.Eventos.Events
{
    using Domain.Core.Events;

    public class EventoEventHandler :
        IHandler<EventoRegistradoEvent>,
        IHandler<EventoAtualizadoEvent>,
        IHandler<EventoExcluidoEvent>
    {
        public void Handle(EventoRegistradoEvent message)
        {
            // Enviar um e-mail
        }

        public void Handle(EventoAtualizadoEvent message)
        {
            // Enviar um e-mail
        }

        public void Handle(EventoExcluidoEvent message)
        {
            // Enviar um e-mail
        }
    }
}
