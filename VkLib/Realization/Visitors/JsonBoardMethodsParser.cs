using System;
using Newtonsoft.Json.Linq;
using VkLib.Abstraction.Domain;
using VkLib.Abstraction.Visitors;
using VkLib.Methods.Board;

namespace VkLib.Realization.Visitors
{
    public class JsonBoardMethodsParser: BaseMethodsVisitor<JToken>, IBoardMethodsVisitor<JToken>
    {
        public JsonBoardMethodsParser(IVkObjectVisitor<JToken> v) : base(v)
        {
        }

        public String VisitAddTopic(AddTopic method, JToken data)
        {
            return data.SafeGetValue<String>("response");
        }

        public String VisitAddComment(AddComment method, JToken data)
        {
            return data.SafeGetValue<String>("response");
        }

    }
}