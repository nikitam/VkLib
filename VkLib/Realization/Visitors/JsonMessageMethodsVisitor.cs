using System;
using Newtonsoft.Json.Linq;
using VkLib.Abstraction.Domain;
using VkLib.Abstraction.Visitors;
using VkLib.Methods.Messages;

namespace VkLib.Realization.Visitors
{
    public class JsonMessageMethodsParser: BaseMethodsVisitor<JToken>, IMessageMethodsVisitor<JToken>
    {
        public JsonMessageMethodsParser(IVkObjectVisitor<JToken> v) : base(v)
        {
        }

        #region Implementation of IMessageMethodsVisitor<string>

        public String VisitMessageSend(Send method, JToken data)
        {
            return data.SafeGetValue<String>("response");
        }

        #endregion

        
    }
}