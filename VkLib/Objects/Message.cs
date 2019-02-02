using VkLib.Abstraction.Domain;

namespace VkLib.Objects
{
    public class Message: VkObject
    {
        public override void Accept<T>(IVkObjectVisitor<T> visitor, T data)
        {
            visitor.VisitMessage(this, data);
        }
    }
}