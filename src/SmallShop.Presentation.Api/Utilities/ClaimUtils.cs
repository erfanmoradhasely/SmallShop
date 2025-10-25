using System.Security.Claims;

namespace SmallShop.Presentation.Api.Utilities;

public static class ClaimUtils
{
    public static Guid GetUserId(this ClaimsPrincipal principal)
    {
        if (principal == null)
            throw new ArgumentNullException(nameof(principal));

        return Guid.Parse(principal.FindFirst(ClaimTypes.NameIdentifier)?.Value);
    }
}