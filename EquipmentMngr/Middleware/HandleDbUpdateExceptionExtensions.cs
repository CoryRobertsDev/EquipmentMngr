using Microsoft.AspNetCore.Builder;

namespace EquipmentMngr.Middleware
{
    public static class HandleDbUpdateExceptionExtensions
    {
        public static IApplicationBuilder UseDbUpdateExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DbUpdateExceptionHandler>();
        }
    }
}