namespace VkLib.Abstraction.Domain
{
    public interface IVkObject
    {
        void Accept<T>(IVkObjectVisitor<T> visitor, T data);
    }
}