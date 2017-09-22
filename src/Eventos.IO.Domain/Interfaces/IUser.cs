
namespace Eventos.IO.Domain.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;

    public interface IUser
    {
        string Name { get; }
        Guid GetUserId();
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
