using System;
using VkLib.Methods.Messages;

namespace VkLib.Abstraction.Visitors
{
    public interface IMessageMethodsVisitor<T>
    {
        String VisitMessageSend(Send method, T data);
    }
}