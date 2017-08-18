
namespace Eventos.IO.Domain.Core.Commands
{
    using System;
    using Events;

    public class Command : Message
    {
        public DateTime Timestamp { get; set; }

        public Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
