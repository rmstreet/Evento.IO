
namespace Eventos.IO.Domain.Core.Events
{
    using System;

    public abstract class Event : Message
    {
        public DateTime Timestamp { get; set; }

        public Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
