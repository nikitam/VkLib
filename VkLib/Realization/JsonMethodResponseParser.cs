using System;
using Newtonsoft.Json.Linq;
using VkLib.Abstraction;
using VkLib.Abstraction.Domain;
using VkLib.Abstraction.Visitors;
using VkLib.Objects;
using VkLib.Realization.Visitors;

namespace VkLib.Realization
{
    public class JsonMethodResponseParser: VkMethodVisitor<JToken>
    {
        public JsonMethodResponseParser(String data, ExecuteEnvironment env) : base(JToken.Parse(data), env)
        {
        }

        protected override IBoardMethodsVisitor<JToken> CreateBoardMethodsVisitor()
        {
            return new JsonBoardMethodsParser(this.CreateVkObjectVisitor());
        }

        protected override IFriendMethodsVisitor<JToken> CreateFriendMethodsVisitor()
        {
            return new JsonFriendMethodsParser(this.CreateVkObjectVisitor());
        }

        protected override IGroupMethodsVisitor<JToken> CreateGroupMethodsVisitor()
        {
            return new JsonGroupMethodsParser(this.CreateVkObjectVisitor());
        }

        protected override IMessageMethodsVisitor<JToken> CreateMessageMethodsVisitor()
        {
            return new JsonMessageMethodsParser(this.CreateVkObjectVisitor());
        }

        protected override IPhotoMethodsVisitor<JToken> CreatePhotoMethodsVisitor()
        {
            return new JsonPhotoMethodsParser(this.CreateVkObjectVisitor());
        }

        protected override IUserMethodsVisitor<JToken> CreateUserMethodsVisitor()
        {
            return new JsonUserMethodsParser(this.CreateVkObjectVisitor());
        }

        protected override Error ParseError()
        {
            var error = new Error();
            error.Accept(this.ObjectsVisitor, this.Data);

            return error;
        }

        protected override IVkObjectVisitor<JToken> CreateVkObjectVisitor()
        {
            return new JsonVkObjectParser();
        }
    }
}