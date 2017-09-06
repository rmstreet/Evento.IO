
namespace Eventos.IO.Infra.CrossCutting.Bus
{
    using System;
    using Eventos.IO.Domain.Core.Bus;
    using Eventos.IO.Domain.Core.Commands;
    using Eventos.IO.Domain.Core.Events;
    using Eventos.IO.Domain.Core.Notifications;

    public sealed class InMemoryBus : IBus
    {
        
        public void RaiseEvent<T>(T theEvent) where T : Event
        {
            Publish(theEvent);
        }

        public void SendCommand<T>(T theCommand) where T : Command
        {
            Publish(theCommand);
        }

        /* Necessario para pode obter acesso ao mecanismode Injeção de Dependencia daqui, assim podemos 
           resolver qualquer tipo de Injeção de Dependencia sem precisar conhecer o seu Resolve.
        */
        #region Obter o mecanismo de DI 
        // TODO: Obter o mecanismo de DI

            public static Func<IServiceProvider> ContainerAccessor { get; set; }

            private static IServiceProvider Container => ContainerAccessor();

            private static void Publish<T>(T message) where T : Message
            {
                if (Container == null) return;

                var obj = Container.GetService(message.MessageType.Equals("DomainNotification")
                    ? typeof(IDomainNotificationHandler<T>)
                    : typeof(IHandler<T>));

                ((IHandler<T>)obj).Handle(message);
            }
        #endregion

    }
}
