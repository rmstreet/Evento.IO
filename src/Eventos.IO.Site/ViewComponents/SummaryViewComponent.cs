﻿
namespace Eventos.IO.Site.ViewComponents
{
    using Eventos.IO.Domain.Core.Notifications;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class SummaryViewComponent : ViewComponent
    {
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;

        public SummaryViewComponent(IDomainNotificationHandler<DomainNotification> notifications)
        {
            _notifications = notifications;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notificacoes = await Task.FromResult(_notifications.GetNotifications());

            notificacoes.ForEach(n => ViewData.ModelState.AddModelError(string.Empty, n.Value));

            return View();
        }

    }
}
