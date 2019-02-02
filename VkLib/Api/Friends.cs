using System;
using System.Collections.Generic;
using VkLib.Abstraction;
using VkLib.Methods.Friends;
using VkLib.Objects;

namespace VkLib.Api
{
    public class Friends
    {
        public static List<User> Get(IExecuteSystem es, String userId, String order, List<String> fields = null, List<String> lists = null,
            Int32? count = null, Int32? offset = null, String nameCase = null)
        {
            var method = new Get
            {
                UserId = userId,
                Order = order,
                Lists = lists,
                Count = count,
                Offset = offset,
                Fields = fields,
                NameCase = nameCase
            };
            return es.Execute(method);
        }

        public static String Add(IExecuteSystem es, String userId, String text, Boolean? follow = null)
        {
            var method = new Add
            {
                UserId = userId,
                Text = text,
                Follow = follow
            };

            return es.Execute(method);
        }
    }

}