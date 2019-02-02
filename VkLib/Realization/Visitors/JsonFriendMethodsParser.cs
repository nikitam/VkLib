using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using VkLib.Abstraction.Domain;
using VkLib.Abstraction.Visitors;
using VkLib.Methods.Friends;
using VkLib.Objects;

namespace VkLib.Realization.Visitors
{
    public class JsonFriendMethodsParser: BaseMethodsVisitor<JToken>, IFriendMethodsVisitor<JToken>
    {
        public JsonFriendMethodsParser(IVkObjectVisitor<JToken> v) : base(v)
        {
        }

        #region Implementation of IFriendMethodsVisitor<string>

        public List<User> VisitFriendsGet(Get method, JToken data)
        {
            var result = new List<User>();
            foreach (var userJson in data["response"]["items"])
            {
                var user = new User();
                user.Accept(this.ObjectParser, userJson);
                result.Add(user);
            }

            return result;
        }

        public String VisitFriendsAdd(Add method, JToken data)
        {
            return data.SafeGetValue<String>("response");
        }

        #endregion

        
    }
}