using System;

namespace VkLib.Abstraction
{
    public interface IVkMethod
    {
        String Name { get; }

        Boolean NeedAuthentication { get; }
    }

    public interface IVkMethod<TOutput> : IVkMethod
    {
        TOutput Accept<T>(VkMethodVisitor<T> visitor, T data);
    }
}