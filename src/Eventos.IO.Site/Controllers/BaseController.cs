
namespace Eventos.IO.Site.Controllers
{
    using Eventos.IO.Domain.Core.Notifications;
    using Microsoft.AspNetCore.Mvc;

    public class BaseController : Controller
    {
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;

        public BaseController(IDomainNotificationHandler<DomainNotification> notifications)
        {
            _notifications = notifications;
        }

        protected bool OperacaoValida()
        {
            return (!_notifications.HasNotifications());
        }
    }
}
