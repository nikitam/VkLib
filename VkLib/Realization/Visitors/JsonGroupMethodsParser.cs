using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using VkLib.Abstraction.Domain;
using VkLib.Abstraction.Visitors;
using VkLib.Methods.Groups;
using VkLib.Objects;

namespace VkLib.Realization.Visitors
{
    public class JsonGroupMethodsParser: BaseMethodsVisitor<JToken>, IGroupMethodsVisitor<JToken>
    {
        public JsonGroupMethodsParser(IVkObjectVisitor<JToken> v) : base(v)
        {
        }

        #region Implementation of IGroupMethodsVisitor<string>

        public List<Group> VisitGroupsGet(Get method, JToken data)
        {
            var result = new List<Group>(data["response"].SafeGetValue<Int32>("count"));

            foreach (var groupItem in data["response"]["items"])
            {
                var group = new Group();
                group.Accept(this.ObjectParser, groupItem);
                result.Add(group);
            }

            return result;
        }

        public List<IsMemberResult> VisitGroupsIsMember(IsMember method, JToken data)
        {
            var result = new List<IsMemberResult>();

            foreach (var item in data["response"])
            {
                var r = new IsMemberResult
                {
                    UserId = item.SafeGetValue<String>("user_id"),
                    IsMember = item.SafeGetValue<Boolean>("member"),
                    HaveRequest = item.SafeGetValue<Boolean>("request"),
                    Invited = item.SafeGetValue<Boolean>("invitation")
                };

                result.Add(r);
            }

            return result;
        }

        #endregion

    }
}