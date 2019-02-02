using VkLib.Abstraction.Domain;

namespace VkLib.Objects.ServiceObjects
{
    public abstract class ServiceObject: IVkObject
    {
        public abstract void Accept<T>(IVkObjectVisitor<T> visitor, T data);
    }
}