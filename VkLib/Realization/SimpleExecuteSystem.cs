using System;
using System.Globalization;
using VkLib.Abstraction;
using VkLib.Realization.Http;

namespace VkLib.Realization
{
    public class SimpleExecuteSystem: HttpExecuteSystem
    {
        public SimpleExecuteSystem(IAuthenticationProvider p): base(p)
        {
            
        }

        protected override ExecuteEnvironment CreateEnvironment()
        {
            return new SimpleExecuteEnvironment(CultureInfo.CurrentCulture);
        }

        public static SimpleExecuteSystem Create(String at, String userId)
        {
            return new SimpleExecuteSystem(new SimpleAuthProvider(userId, at));
        }
    }
}