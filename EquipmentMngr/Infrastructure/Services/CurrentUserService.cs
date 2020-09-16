using System;
using EquipmentMngr.Helpers;
using Microsoft.AspNetCore.Http;

namespace EquipmentMngr.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public string GetCurrentUsername()
        {
            return _httpContextAccessor.HttpContext.User.Identity.Name;
        }
    }
}