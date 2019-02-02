using Newtonsoft.Json.Linq;
using VkLib.Abstraction.Domain;
using VkLib.Abstraction.Visitors;
using VkLib.Methods.Users;
using VkLib.Objects;

namespace VkLib.Realization.Visitors
{
    public class JsonUserMethodsParser: BaseMethodsVisitor<JToken>, IUserMethodsVisitor<JToken>
    {
        public JsonUserMethodsParser(IVkObjectVisitor<JToken> v) : base(v)
        {
        }

        #region Implementation of IUserMethodsVisitor<string>

        public User VisitUsersGet(Get method, JToken data)
        {
            var user = new User();
            user.Accept(this.ObjectParser, data["response"][0]);
            return user;
        }

        #endregion

        
    }
}