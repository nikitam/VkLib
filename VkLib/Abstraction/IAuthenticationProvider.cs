using System;

namespace VkLib.Abstraction
{

    public interface IAuthenticationProvider
    {
        String PrincipalId { get; }

        String AccessToken { get; }

        Boolean IsAuthenticated { get; }
    }
}