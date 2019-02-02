using System;
using VkLib.Abstraction;

namespace VkLib.Realization
{
    public class SimpleAuthProvider: IAuthenticationProvider
    {
        public SimpleAuthProvider(String principalId, String accessToken)
        {
            this.PrincipalId = principalId;
            this.AccessToken = accessToken;
        }


        public String PrincipalId { get; }

        public String AccessToken { get; }

        public Boolean IsAuthenticated
        {
            get { return true; }
        }
    }
}