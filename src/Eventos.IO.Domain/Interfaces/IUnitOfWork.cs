
namespace Eventos.IO.Domain.Interfaces
{
    using global::Eventos.IO.Domain.Core.Commands;
    using System;

    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
