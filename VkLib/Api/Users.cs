using System;
using System.Collections.Generic;
using VkLib.Abstraction;
using VkLib.Methods.Users;
using VkLib.Objects;

namespace VkLib.Api
{
    public class Users
    {
        public static User Get(IExecuteSystem es, List<String> userIds, List<String> fields = null,
            String nameCase = null)
        {
            var method = new Get
            {
                UserIds = userIds,
                Fields = fields,
                NameCase = nameCase
            };
            return es.Execute(method);
        }

        public static User Get(IExecuteSystem es, String userId, List<String> fields = null,
            String nameCase = null)
        {
            var method = new Get
            {
                UserIds = new List<String>
                {
                    userId
                },
                Fields = fields,
                NameCase = nameCase
            };
            return es.Execute(method);
        }
    }

}