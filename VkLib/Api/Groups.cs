using System;
using System.Collections.Generic;
using VkLib.Abstraction;
using VkLib.Methods.Groups;
using VkLib.Objects;

namespace VkLib.Api
{
    public class Groups
    {
        public static List<Group> Get(IExecuteSystem es, String userId, Boolean? extended = true,
            String filter = null, List<String> fields = null, Int32? count = null, Int32? offset = null)
        {
            var method = new Get
            {
                Count = count,
                Extended = extended,
                Fields = fields,
                Filter = filter,
                Offset = offset,
                UserId = userId
            };

            return es.Execute(method);
        }

        public static List<IsMemberResult> IsMember(IExecuteSystem es, String groupId,
            List<String> userIds)
        {
            var method = new IsMember
            {
                GroupId = groupId,
                UserIds = userIds
            };

            return es.Execute(method);
        }
    }
}