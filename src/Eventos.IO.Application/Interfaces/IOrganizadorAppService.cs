
namespace Eventos.IO.Application.Interfaces
{
    using Eventos.IO.Application.ViewModels;
    using System;
    public interface IOrganizadorAppService : IDisposable
    {
        void Registrar(OrganizadorViewModel organizadorViewModel);
    }
}
