﻿
namespace Eventos.IO.Infra.CrossCutting.Identity.Models
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using Domain.Interfaces;
    using Microsoft.AspNetCore.Http;

    public class AspNetUser : IUser
    {

        private readonly IHttpContextAccessor _accessor;
        
        public AspNetUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Name => _accessor.HttpContext.User.Identity.Name;

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }

        public Guid GetUserId()
        {
            return IsAuthenticated() ? Guid.Parse(_accessor.HttpContext.User.GetUserId()) : Guid.NewGuid();
        }

        public bool IsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
