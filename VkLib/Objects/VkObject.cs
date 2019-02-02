using VkLib.Abstraction.Domain;

namespace VkLib.Objects
{
    public abstract class VkObject: IVkObject
    {
        public abstract void Accept<T>(IVkObjectVisitor<T> visitor, T data);
    }
}