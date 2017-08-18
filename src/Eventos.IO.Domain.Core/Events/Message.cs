
namespace Eventos.IO.Domain.Core.Events
{
    using System;

    public abstract class Message
    {
        public string MessageType { get; set; }
        public Guid AggregateId { get; set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }

    }
}
