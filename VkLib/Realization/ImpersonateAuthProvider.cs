using System;
using VkLib.Abstraction;

namespace VkLib.Realization
{
    public class ImpersonateAuthProvider: IAuthenticationProvider
    {
        public ImpersonateAuthProvider()
        {
            this.IsAuthenticated = false;
            this.AccessToken = null;
            this.PrincipalId = null;
        }

        public String PrincipalId { get; }

        public String AccessToken { get; }

        public Boolean IsAuthenticated { get; }
    }
}