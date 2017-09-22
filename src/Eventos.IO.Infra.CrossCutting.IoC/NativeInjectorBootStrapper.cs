
namespace Eventos.IO.Infra.CrossCutting.IoC
{
    using AutoMapper;
    using Eventos.IO.Application.Interfaces;
    using Eventos.IO.Application.Services;
    using Eventos.IO.Domain.Core.Bus;
    using Eventos.IO.Domain.Core.Events;
    using Eventos.IO.Domain.Core.Notifications;
    using Eventos.IO.Domain.Eventos.Command;
    using Eventos.IO.Domain.Eventos.Commands;
    using Eventos.IO.Domain.Eventos.Events;
    using Eventos.IO.Domain.Eventos.Repository;
    using Eventos.IO.Domain.Interfaces;
    using Eventos.IO.Domain.Organizadores.Commands;
    using Eventos.IO.Domain.Organizadores.Events;
    using Eventos.IO.Domain.Organizadores.Repository;
    using Eventos.IO.Infra.CrossCutting.Bus;
    using Eventos.IO.Infra.Data.Context;
    using Eventos.IO.Infra.Data.Repository;
    using Eventos.IO.Infra.Data.UoW;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;

    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASPNET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // TODO: Levar o DI do Identity para a camada de IoC, quando o identity estiver desacoplado.
            //services.AddScoped<IUser, AspNetUser>();

            // Application
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<IEventoAppService, EventoAppService>();
            services.AddScoped<IOrganizadorAppService, OrganizadorAppService>();

            // Domain - Commands
            services.AddScoped<IHandler<RegistrarEventoCommand>, EventoCommandHandler>();
            services.AddScoped<IHandler<AtualizarEventoCommand>, EventoCommandHandler>();
            services.AddScoped<IHandler<ExcluirEventoCommand>, EventoCommandHandler>();
            services.AddScoped<IHandler<RegistrarOrganizadorCommand>, OrganizadorCommandHandler>();


            // Domain - Events
            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IHandler<EventoRegistradoEvent>, EventoEventHandler>();
            services.AddScoped<IHandler<EventoAtualizadoEvent>, EventoEventHandler>();
            services.AddScoped<IHandler<EventoExcluidoEvent>, EventoEventHandler>();
            services.AddScoped<IHandler<OrganizadorRegistradoEvent>, OrganizadorEventHandler>();

            // Infra - Data
            services.AddScoped<IEventoRepository, EventoRepository>();
            services.AddScoped<IOrganizadorRepository, OrganizadorRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<EventosContext>();

            // Infra - Bus
            services.AddScoped<IBus, InMemoryBus>();

        }
    }
}
