using System;
using VkLib.Methods.Board;

namespace VkLib.Abstraction.Visitors
{
    public interface IBoardMethodsVisitor<T>
    {
        String VisitAddTopic(AddTopic method, T data);
        String VisitAddComment(AddComment method, T data);
    }
}