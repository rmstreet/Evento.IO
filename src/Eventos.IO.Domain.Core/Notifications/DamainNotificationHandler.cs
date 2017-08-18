
namespace Eventos.IO.Domain.Core.Notifications
{
    using System.Collections.Generic;
    using System.Linq;

    public class DamainNotificationHandler : IDomainNotificationHandler<DomainNotification>
    {

        private List<DomainNotification> _notifications;

        public DamainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public List<DomainNotification> GetNotifications()
        {
            return _notifications;
        }

        public void Handle(DomainNotification message)
        {
            _notifications.Add(message);
        }

        public bool HasNotifications()
        {
            return _notifications.Any();
        }

        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }
    }
}
