using System;
using System.Collections.Generic;
using VkLib.Abstraction;
using VkLib.Methods.Messages;

namespace VkLib.Api
{
    public class Messages
    {
        public static String Send(IExecuteSystem es, String userId, String message, String domain = null, String chatId = null, List<String> userIds = null, Guid? unique = null, Double? lat = null, Double? @long = null, List<String> attach = null)
        {
            var method = new Send
            {
                UserId = userId,
                Domain = domain,
                ChatId = chatId,
                UserIds = userIds,
                Message = message,
                Unique = unique,
                Lat = lat,
                Long = @long,
                Attachment = attach
            };
            return es.Execute(method);
        }
    }

}